using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StrongPasswordGen
{
    class Program
    {
        public static RNGCryptoServiceProvider Provider { get; set; } = new RNGCryptoServiceProvider();

        static void Main(string[] args)
        {

            int PasswordAmount = 0;
            int PasswordLength = 0;

            string CapitalLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string SmallLetters = "qwertyuiopasdfghjklzxcvbnm";
            string Digits = "0123456789";
            string SpecialCharacters = "!@#$%^&*()-_=+<,>.";
            string AllChar = CapitalLetters + SmallLetters + Digits + SpecialCharacters;



            Console.WriteLine("\nKiek slaptazodziu norite sugeneruoti ?:");
            PasswordAmount = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite kokio ilgio norite slaptazodziu:");
            PasswordLength = int.Parse(Console.ReadLine());

            string[] AllPasswords = new string[PasswordAmount];


            for (int i = 0; i < PasswordAmount; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int n = 0; n < PasswordLength; n++)
                {
                    sb = sb.Append(GenerateChar(AllChar));
                }

                AllPasswords[i] = sb.ToString();
            }

            Console.WriteLine("Generated passwords:");

            foreach (string singlePassword in AllPasswords)
            {
                Console.WriteLine(singlePassword);
            }


        }

        private static char GenerateChar(string availableChars)
        {
            var byteArray = new byte[1];
            char c;
            do
            {
                Provider.GetBytes(byteArray);
                c = (char)byteArray[0];

            } while (!availableChars.Any(x => x == c));

            return c;
        }
    }
}