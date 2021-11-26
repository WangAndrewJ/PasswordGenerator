using System;
using System.IO;
using System.Collections.Generic;

namespace PasswordGenerator
{
    class Program
    {
        private List<string> accountEmails = new List<string>();
        private Dictionary<string, List<string>> accountsAndPasswords = new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            Program program = new Program();

            // program.MainLoop();
        }

        public void MainLoop()
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=[];',./!@#$%^&*()_+{}|:<>?";
            char[] characterArray = characters.ToCharArray();

            while (true)
            {
                string password = Generate(characters.ToCharArray());
                bool exitLoop = false;

                if (password != string.Empty)
                {
                    Console.WriteLine("Press \"a\" to create a new password. Press \"s\" to save the password. Press \"x\" to exit.");

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.A:
                            Console.Write("\n");
                            break;

                        case ConsoleKey.S:
                            Console.Write("\n");
                            Console.WriteLine("Please type the location of the save file");

                            string path = Console.ReadLine();

                            try
                            {
                                System.IO.File.WriteAllText(@path, password);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("An Error Has Occurred");
                                Console.WriteLine(ex);
                            }

                            break;

                        case ConsoleKey.X:
                            exitLoop = true;
                            break;
                    }

                    if (exitLoop)
                    {
                        break;
                    }
                }
            }
        }

        public void CreateAccount()
        {

        }

        public string Generate(char[] characterArray)
        {
            string password = string.Empty;

            Console.WriteLine("How many characters should your password be?");

            bool isANumber = int.TryParse(Console.ReadLine(), out int numberOfCharacters);

            if (numberOfCharacters >= 1 && numberOfCharacters <= 128 && isANumber)
            {
                Random random = new Random();

                Console.Write("Password Generated: ");

                for (int i = 0; i < numberOfCharacters; i++)
                {
                    password += characterArray[random.Next(0, characterArray.Length)];
                }

                Console.WriteLine(password);
                /*                 Console.WriteLine("Press \"a\" to create a new password. Press \"s\" to save the password. Press \"x\" to exit.");

                                switch (Console.ReadKey().Key)
                                {
                                    case ConsoleKey.A:
                                        Console.Write("\n");
                                        return password;

                                    case ConsoleKey.S:
                                        Console.Write("\n");
                                        Console.WriteLine("Please type the location of the save file");

                                        try
                                        {
                                            string path = Console.ReadLine();

                                            System.IO.File.WriteAllText(@path, password);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("An Error Has Occurred");
                                            Console.WriteLine(ex);
                                        }

                                        break;

                                    case ConsoleKey.X:
                                        break;
                                } */

                return password;
            }
            else
            {
                Console.WriteLine("Please enter a integer number between 2 and 128.");
                return string.Empty;
            }
        }
    }
}
