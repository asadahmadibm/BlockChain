// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");

BlockChain.BlockChain TopCoin=new BlockChain.BlockChain();
TopCoin.InitializeChain();
TopCoin.CreateTranscation(new BlockChain.Transaction("hamed", "ahmad", 2));

TopCoin.ProcessTransaction("hamed");

TopCoin.CreateTranscation(new BlockChain.Transaction("sina", "payam", 5));
TopCoin.CreateTranscation(new BlockChain.Transaction("nima", "arash", 3));

TopCoin.ProcessTransaction("hamed");

Console.WriteLine(JsonSerializer.Serialize(TopCoin, new JsonSerializerOptions { WriteIndented = true }));


Console.Read();