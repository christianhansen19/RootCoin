using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Newtonsoft.Json;
using EllipticCurve;

namespace RootCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            Blockchain rootcoin = new Blockchain();

            rootcoin.AddBlock(new Block(1, DateTime.Now.ToString("yyyyMMddHHmmssffff"), "amount: 50"));
            rootcoin.AddBlock(new Block(2, DateTime.Now.ToString("yyyyMMddHHmmssffff"), "amount: 200"));
            string blockJSON = JsonConvert.SerializeObject(rootcoin, Formatting.Indented);
            Console.WriteLine(blockJSON);
            

            if (rootcoin.IsChainValid())
            {
                Console.WriteLine("Blockchain is valid!");
            }
            else
            {
                Console.WriteLine("Blockchain is not valid.");
            }

            Console.ReadKey();
        }
    }


}
