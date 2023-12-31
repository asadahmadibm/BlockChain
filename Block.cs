﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlockChain
{
    public class Block
    {
        public int Index { get; set; }
        public DateTime TimeStamp { get; set; }
        public string   PreviousHash { get; set; }
        public string Hash { get; set; }
        public IList<Transaction> Transactions { get; set; }
        public int Nonce { get; set; } = 1;

        public Block(DateTime timeStamp,string previousHash, IList<Transaction> transactions) 
        {
            Index= 0;
            TimeStamp = timeStamp;
            PreviousHash= previousHash;
            Transactions = transactions;
            Hash = CalculateHash();

        }

        public string CalculateHash()
        {
            SHA256 sHA256 = SHA256.Create();
            byte[] input = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash}-{JsonSerializer.Serialize(Transactions)}-{Nonce}");
            var output=sHA256.ComputeHash(input);
            return Convert.ToBase64String( output );
        }

        public void Mine(int difficalty)
        {
            var leadingzero = new string('0', difficalty);
            while (this.Hash==null || this.Hash.Substring(0,difficalty)!=leadingzero )
            {
                Nonce++;
              this.Hash=  this.CalculateHash();
            }

        }


    }
}
