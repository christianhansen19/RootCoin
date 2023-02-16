using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace RootCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            Block newBlock = new Block(1, DateTime.Now.ToString("yyyyMMddHHmmssffff"), "amount: 50", "");
            string blockJSON = JsonConvert.SerializeObject(newBlock, Formatting.Indented);
            Console.WriteLine(blockJSON);
            Console.ReadKey();
        }
    }

    class Blockchain
    {

    }

    class Block
    {
        public int Index { get; set; }
        public string PreviousHash { get; set; }
        public string Timestamp { get; set; }
        public string Data { get; set; }
        public string Hash { get; set; }

        public Block(int index, string timestamp, string data, string previousHash ="")
        {
            this.Index = index;
            this.Timestamp = timestamp;
            this.Data = data;
            this.PreviousHash = previousHash;
        }

        public string CalculateHash()
        {
            string blockData = this.Index + this.PreviousHash + this.Timestamp + this.Data;
            byte[] blockBytes = Encoding.ASCII.GetBytes(blockData);
            byte[] hashBytes= SHA256.Create().ComputeHash(blockBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }
    }

}
