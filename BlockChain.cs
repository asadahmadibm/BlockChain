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

        public BlockChain() 
        {
            InitializeChain();
            AddGenesisBlock();
        }

        private void InitializeChain()
        {
            chain= new List<Block>();
        }
        private void AddGenesisBlock()
        {
            chain.Add(CreateGenesisBlock());

        }

        private Block CreateGenesisBlock()
        {
            return new Block(DateTime.Now, null, "{}");
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
            block.Hash=block.CalculateHash();
            chain.Add(block);
        }


    }
}
