using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class BlockChain
    {
        public IList<Block> chain { get; set; }
        public int difficalty { get; set; } = 3;
        public int revard { get; set; }

        IList<Transaction> pendingtransactions=new List<Transaction>();

        public void CreateTranscation(Transaction transaction)
        {
            pendingtransactions.Add(transaction);
        }

        public void ProcessTransaction(string minerAddress)
        {
            Block block=new Block(DateTime.Now,GetLatestBlock().Hash, pendingtransactions);
            AddBlock(block);
            pendingtransactions=new List<Transaction>();
            CreateTranscation(new Transaction(null, minerAddress, revard));
        }

        public void InitializeChain()
        {
            chain= new List<Block>();
            AddGenesisBlock();
        }
        private void AddGenesisBlock()
        {
            chain.Add(CreateGenesisBlock());

        }

        private Block CreateGenesisBlock()
        {
            Block block= new Block(DateTime.Now, null, pendingtransactions);
            block.Mine(difficalty);
            return block;
        }

        public Block GetLatestBlock()
        {
            return chain[chain.Count-1];

        }

        public void AddBlock(Block block)
        {
            Block latestblock= GetLatestBlock();
            block.Index= latestblock.Index+1;
            block.PreviousHash= latestblock.Hash;
            block.Mine(difficalty);
            chain.Add(block);
        }

        public bool IsValid()
        {
            for (int i = 1; i < chain.Count; i++)
            {
                Block currentBlock = chain[i];
                Block previousBlock = chain[i-1];
                if(currentBlock.Hash!=currentBlock.CalculateHash())
                    return false;
                if(currentBlock.PreviousHash!=previousBlock.Hash) 
                    return false;
            }
            return true;
        }
    }
}
