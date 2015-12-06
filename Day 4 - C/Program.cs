using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Day_4___C
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry = "bgvyzdsv";
            int sortie = 1;
            string num = "0";

            while (sortie == 1)
            {
                string hash; 
                StringBuilder test = new StringBuilder();
                test.Append(entry);
                test.Append(num);
                string input = test.ToString();
                MD5 md5Hash = MD5.Create();
            
                hash = GetMd5Hash(md5Hash, input);
                
            

                
            int convert = int.Parse(num);
            convert++;
            num = convert.ToString();

                char carac = '0';
                int i = 0;
                while(carac == '0' && i <= 7){
                    carac = hash[i];
                    i++;
                }

         

            if (i == 7)
            {
                Console.WriteLine(hash);
                Console.WriteLine(test);
                sortie = 0;
            }
            


            }

            Console.ReadLine();

        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
