using System.ComponentModel.DataAnnotations;
using System.Text;

namespace roshambo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("RO-SHAM-BO");
            startGame();

            string[] continueOptions = {"Yes", "No"};
            int con = convertUserInputToChoice(continueOptions);
            while (con == 1)
            {
                
                startGame();
                con = convertUserInputToChoice(continueOptions);
            }

            Console.WriteLine("Thanks for playing!");

        }
        public static void startGame()
        {
            Console.WriteLine("Choose your game limit");
            string[] limitOptions = { "2/3", "3/4", "4/5" };
            int limit = convertUserInputToChoice(limitOptions);
            string limitChoice = limitOptions[limit - 1];
            gameLoop(limitChoice);
        }
        public static void gameLoop(string turnLimit)
        {
            int advantage = int.Parse($"{turnLimit[0]}");
            int limit = int.Parse($"{turnLimit[2]}");
            Console.WriteLine($"{advantage}, {limit}");
            bool looping = true;
            int round = 1;
            int playerScore = 0, cpuScore = 0;
            while (looping)
            {
                string[] moves = { "Rock", "Paper", "Scissors" };
                Console.WriteLine($"Round {round} of {limit}");
                Console.WriteLine("Choose your move: ");

                int userAgentChoice = convertUserInputToChoice(moves);

                Console.WriteLine("Rock Paper Scissors");

                Random cpuAgentGen = new Random();
                int cpuAgentChoice = cpuAgentGen.Next(1, 4);

                Console.WriteLine("SHOOT");
                Console.WriteLine($"You chose {moves[userAgentChoice - 1]}");
                Console.WriteLine($"I chose {moves[cpuAgentChoice - 1]}\n");


                string winner = determineWinner(userAgentChoice, cpuAgentChoice);
                if(string.Compare(winner, "Tie") == 0 )
                {
                    Console.WriteLine("This round was a tie!");
                }
                else
                {
                    Console.WriteLine($"{winner} wins this round!");
                    if (string.Compare(winner, "Player") == 0)
                    {
                        playerScore++;
                    }
                    else
                    {
                        cpuScore++;
                    }
                }
                Console.WriteLine($"Current Score: You: {playerScore}, Me: {cpuScore}");
                
                
                if (Math.Abs(playerScore - cpuScore) == advantage || round == limit)
                {
                  
                    string gameWin = playerScore > cpuScore ? "Player" : "CPU";
                    Console.WriteLine($"{gameWin} wins the game!");
                    looping = false;
                }

                round++;

                


            }

            
        }

        public static string determineWinner(int user, int cpu)
        {
            string winner;

            if (user == cpu)
            {
                winner = "Tie";
            }
            else if (user == 1 && cpu == 3 || user == 2 && cpu == 1 || user == 3 && cpu == 2) 
            {
                    winner = "Player";
            }
            else
            {
                winner = "cpu";
            }

            return winner;
        }


    public static int convertUserInputToChoice(string[] options)
        {
            // Print all of the options for the user to choose from with the associate option
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            string? userChoiceInput = Console.ReadLine();
            int userChoice = -1;
            while (userChoice < 1)
            {
                if (userChoiceInput != null)
                {
                    // need to validate user input by string or by number
                    // allow either string or number
                    if (userChoiceInput.Length == 1)
                    {
                        userChoice = int.Parse(userChoiceInput);
                        if (userChoice < 0 || userChoice > options.Length)
                        {
                            Console.WriteLine($"Please provide a number in valid input range (1-{options.Length})");
                        }
                    }
                    else if (userChoiceInput.Length > 1)
                    {
                        for (int i = 0; i < options.Length; i++)
                        {
                            bool matchesMoveI = string.Compare(userChoiceInput, options[i]) == 0;
                            if (matchesMoveI)
                            {
                                userChoice = i + 1;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please input a number or string matching what is displayed.");
                    }

                }
                else
                {
                    // string input is null and that also needs to be handled

                }
            }


            return userChoice;
        }
    }
} 

 