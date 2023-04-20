namespace DiceRoller
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool goOn = true;
            bool invalid = false;
            int input = -1;
            do
            {
                Console.WriteLine("How many sides should each die have?");
                do
                {
                    input = ForceInt();
                    if (input < 1)
                    {
                        Console.WriteLine("Pick a number greater than 0");
                        invalid = true;
                    }
                    else
                    {
                        invalid = false;
                    }
                } while (invalid == true);
                
                int roll1 = RollDice(input);
                int roll2 = RollDice(input);
                Console.WriteLine($"You rolled a {roll1} and a {roll2} ({roll1 + roll2} total)");
                if (input == 6)
                {
                    if (Wins1For6(roll1, roll2) != "")
                    {
                        Console.WriteLine(Wins1For6(roll1, roll2));
                    }
                    if (Wins2For6(roll1, roll2) != "")
                    {
                        Console.WriteLine(Wins2For6(roll1, roll2));
                    }
                }
                if (input == 20)
                {
                    if (WinsFor20(roll1) != "")
                    {
                        Console.WriteLine(WinsFor20(roll1));
                    }
                    if (WinsFor20(roll2) != "")
                    {
                        Console.WriteLine(WinsFor20(roll2));
                    }
                }
                if (input == 1)
                {
                    Console.WriteLine("How did you even roll something with 1 side?");
                }
                goOn = Continue();
            } while (goOn);
        }
        static int ForceInt()
        {
            int input = -1;
            while(!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a valid number");
            }
            return input;
        }
        static int RollDice(int max)
        {
            Random r = new Random();
            int roll = r.Next(1,max+1);
            return roll;
        }
        static string Wins1For6(int input1, int input2)
        {
            if(input1 == 1 && input2 == 1)
            {
                return "Snake eyes!";
                
            }
            else if (input1 + input2 == 3)
            {
                return "Ace Deuce!";
                
            }
            else if (input1 == 2 && input2 == 2)
            {
                return "Box Cars!";
            }
            else
            {
                return "";
            }
        }
        static string Wins2For6(int input1, int input2)
        {
            if (input1 == 1 && input2 == 1)
            {
                return "Craps!";
            }
            else if (input1 + input2 == 3)
            {
                return "Craps!";
            }
            else if (input1 == 2 && input2 == 2)
            {
                return "Craps!";
            }
            else if (input1 + input2 == 7 || input1 + input2 == 11)
            {
                return "Win!";
            }
            else
            {
                return "";
            }
        }
        static string WinsFor20(int input1)
        {
            if (input1 == 20)
            {
                return "Critical Hit!";
            }
            else if (input1 == 1)
            {
                return "Critical Miss!";
            }
            else
            {
                return "";
            }
        }
        static bool Continue()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like to continue? y/n");
            string input = Console.ReadLine().ToLower().Trim();
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                return Continue();
            }
        }
    }
}