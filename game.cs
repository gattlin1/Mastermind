using System;
using System.Linq;
using System.Collections.Generic;
namespace mastermind
{
    public class Game
    {
        public int num_tries{ get; private set; }
        public HashSet<string> peg_color = new HashSet<string> { "red", "blue", "green", "yellow", "pink", "white", "black", "empty" };
        private const int CODE_LENGTH = 4;
        private string[] code = new string[CODE_LENGTH], user_guess = new string[CODE_LENGTH];

        public Game()
        {
            num_tries = 10;
            code = generate_code();
        }

        public Game(int tries)
        {
            num_tries = tries;
            code = generate_code();
        }

        // Generates a random code of desired code length
        private string[] generate_code()
        {
            Random rnd = new Random();
            string [] code_as_array = peg_color.ToArray();
            for (int i = 0; i < CODE_LENGTH; i++)
            {
                code[i] = code_as_array[(rnd.Next(peg_color.Count))];
            }
            return code;
        }

        public void guess_code()
        {
            string input;

            do{
                Console.WriteLine($"You have {num_tries} left.\nPlease put spaces inbetween each" +
                                " color in you guess. What is your guess?");
                input = Console.ReadLine();
                user_guess = input.Split(' ');
            }
            while(!(desired_len() && correct_spelling()));
            --num_tries;
        }

        private bool desired_len()
        {
            if (user_guess.Length != CODE_LENGTH)
            {
                Console.WriteLine($"You entered in {user_guess.Length} colors. You need {CODE_LENGTH} colors.");
                return false;
            }
            else
            {
                return true;
            }
        }

        // To ensure there is no error when converting the guess into enum values
        private bool correct_spelling()
        {
            for (int i = 0; i < user_guess.Length; i++)
            {
                if (!peg_color.Contains(user_guess[i].ToLower()))
                {
                    Console.WriteLine($"Incorrect spelling for the input: {user_guess[i]}");
                    Console.WriteLine("The correct colors are: ");
                    display_set();

                    return false;
                }
            }
            return true;
        }

        private void display_set()
        {
            foreach (string color in peg_color)
            {
                Console.Write(" {0}  ", color);
            }
            Console.WriteLine();
        }

        public void compare()
        {
            int same_color = 0, same_place_and_color = 0;
            string[] code_to_compare = new string[CODE_LENGTH];
            Array.Copy(code, 0, code_to_compare, 0, CODE_LENGTH);

            for (int i = 0; i < user_guess.Length; i++)
            {
                if (user_guess[i] == code_to_compare[i])
                {
                    ++same_place_and_color;
                }
            }
            for (int i = 0; i < user_guess.Length; i++)
            {
                for (int j = 0; j < code_to_compare.Length; j++)
                {
                    if (user_guess[i] == code_to_compare[j])
                    {
                        code_to_compare[j] = null; // to prevent duplicate colors from double counting
                        ++same_color;
                    }
                }
            }
            response(same_place_and_color, same_color);
        }

        private void response(int same_place_and_color, int same_color)
        {
            if (same_place_and_color == CODE_LENGTH) {
                Console.WriteLine("You guessed the code!");
                num_tries = 0;
            }
            else if (num_tries == 0)
            {
                Console.WriteLine("Game Over!");
                Console.Write("The code was: ");
                for(int i = 0; i < CODE_LENGTH; i++) {
                    Console.Write(" {0} ", code[i]);
                }
            }
            else {
                Console.WriteLine($"Same place and color: {same_place_and_color}");
                Console.WriteLine($"Same color: {same_color}");
                Console.WriteLine();
            }
        }

        public bool is_game_over()
        {
            return num_tries <= 0;
        }
    }
}