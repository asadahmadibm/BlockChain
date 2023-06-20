// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Hello, World!");
DateTime startTime= DateTime.Now;
BlockChain.BlockChain TopCoin=new BlockChain.BlockChain();
TopCoin.AddBlock(new BlockChain.Block(DateTime.Now, null, "Sender:asad,Reciever:hamed,amount:2"));
TopCoin.AddBlock(new BlockChain.Block(DateTime.Now, null, "Sender:karim,Reciever:vahid,amount:3"));
DateTime endTime= DateTime.Now;
Console.WriteLine(JsonSerializer.Serialize(TopCoin, new JsonSerializerOptions { WriteIndented = true }));
Console.WriteLine(endTime - startTime);
//Console.WriteLine("Is Valid"+TopCoin.IsValid());
//Console.Read();

//TopCoin.chain[2].Data = "Sender:karim,Reciever:gholi,amount:3";

//Console.WriteLine("Is Valid" + TopCoin.IsValid());
Console.Read();