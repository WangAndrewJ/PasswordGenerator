using System;

namespace PasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890-=[];',./!@#$%^&*()_+{}|:<>?";
            char[] characterArray = characters.ToCharArray();

            while (true)
            {
                Console.WriteLine("How many characters should your password be?");

                bool isANumber = int.TryParse(Console.ReadLine(), out int numberOfCharacters);

                if (numberOfCharacters > 0 && numberOfCharacters < 2001 && isANumber)
                {
                    Random random = new Random();

                    Console.Write("Password Generated: ");

                    for (int i = 0; i < numberOfCharacters; i++)
                    {
                        Console.Write(characterArray[random.Next(0, characterArray.Length)]);
                    }

                    Console.Write("\n");

                    Console.WriteLine("Press \"a\" to create a new password. Press \"s\" to save the password. Press any other key to close the program.");

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.A:
                            Console.Write("\n");
                            continue;

                        case ConsoleKey.S:
                            Console.Write("\n");
                            // Save Password
                            break;

                        default:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a integer number above 0 and below 2001.");
                }
            }

        }
    }
}
