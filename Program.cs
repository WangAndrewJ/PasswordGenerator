using System;
using System.IO;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=[];',./!@#$%^&*()_+{}|:<>?";
            char[] characterArray = characters.ToCharArray();
            string password = string.Empty;

            while (true)
            {
                Console.WriteLine("How many characters should your password be?");

                bool isANumber = int.TryParse(Console.ReadLine(), out int numberOfCharacters);

                if (numberOfCharacters > 1 && numberOfCharacters < 2001 && isANumber)
                {
                    Random random = new Random();

                    Console.Write("Password Generated: ");

                    for (int i = 0; i < numberOfCharacters; i++)
                    {
                        password += characterArray[random.Next(0, characterArray.Length)];
                    }

                    Console.WriteLine(password);
                    Console.WriteLine("Press \"a\" to create a new password. Press \"s\" to save the password. Press any other key to close the program.");

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.A:
                            Console.Write("\n");
                            continue;

                        case ConsoleKey.S:
                            Console.Write("\n");
                            Console.WriteLine("Please type the location of the save file");

                            try
                            {
                                string path = Console.ReadLine();

                                TextWriter writer = new StreamWriter(path, true);

                                writer.Write(password);
                                writer.Write("\n");
                                writer.Close();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                            break;

                        default:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a integer number above 1 and below 2001.");
                }
            }

        }
    }
}
