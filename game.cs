using System;
using System.Linq;

namespace mastermind
{
    public class Game
    {
        public int num_tries{ get; private set; }
        public enum peg_color { Red, Blue, Green, Yellow, Pink, White, Black, Empty };
        private const int CODE_LENGTH = 4;
        private peg_color[] code = new peg_color[CODE_LENGTH], user_guess = new peg_color[CODE_LENGTH];

        // At declaration, generate the code to be guessed by the user.
        public Game(int tries)
        {
            num_tries = tries;
            code = generate_code();
        }
        
        // Generates a random code of desired code length
        private peg_color[] generate_code()
        {
            Array colors = Enum.GetValues(typeof(peg_color));
            Random rnd = new Random();
            peg_color[] code = new peg_color[CODE_LENGTH];
            for (int i = 0; i < CODE_LENGTH; i++)
            {
                code[i] = (peg_color)colors.GetValue(rnd.Next(0,7));
            }
            return code;
        }

        public void guess_code() 
        {
            string input;
            string [] input_split_to_array = new string[CODE_LENGTH];

            do{
                Console.WriteLine($"You have {num_tries} left.\nPlease put spaces inbetween each" +
                                " color in you guess. What is your guess?");
                input = Console.ReadLine();
                input_split_to_array = input.Split(' ');
            }
            while(!(desired_len(input_split_to_array) && correct_spelling(input_split_to_array)));
            --num_tries;

            convert_to_peg(input_split_to_array);

            for (int i = 0; i < user_guess.Length; i++)
            {
                Console.Write(user_guess[i] + ", ");
            }
        }

        private bool desired_len(string[] guess)
        {
            if (guess.Length != CODE_LENGTH)
            {
                Console.WriteLine($"You entered in {guess.Length} colors. You need {CODE_LENGTH}");
                return false;
            }
            else 
            {
                return true;
            }
        }

        // To ensure there is no error when converting the guess into enum values
        private bool correct_spelling(string[] guess)
        {
            string[] correct_spelled_colors = new string[]{ "red", "blue", "green", "yellow", "pink", "white", "black" };
            for (int i = 0; i < guess.Length; i++)
            {
                if (!correct_spelled_colors.Contains(guess[i].ToLower()))
                {
                    Console.WriteLine($"Incorrect spelling for the input: {guess[i]}");
                    return false;
                }
            }
            return true;
        }

        private void convert_to_peg(string[] guess_input)
        {
            for (int i = 0; i < guess_input.Length; i++) 
            {
                switch(guess_input[i].ToLower())
                {
                    case "red": { user_guess[i] = peg_color.Red;
                        break;
                    }
                    case "blue": { user_guess[i] = peg_color.Blue;
                        break;
                    }
                    case "green": { user_guess[i] = peg_color.Green;
                        break;
                    }
                    case "yellow": {  user_guess[i] = peg_color.Yellow;
                        break;
                    }
                    case "pink": { user_guess[i] = peg_color.Pink;
                        break;
                    }
                    case "white": { user_guess[i] = peg_color.White;
                        break;
                    }
                    case "black": { user_guess[i] = peg_color.Black;
                        break;
                    }
                    default : { user_guess[i] = peg_color.Empty; //should not reach here.
                        break;
                    };
                }
            }
            
        }

        public void compare()
        {
            int same_color = 0, same_place_and_color = 0;

            for (int i = 0; i < user_guess.Length; i++) 
            {
                if (user_guess[i] == code[i])
                {
                    ++same_place_and_color;
                }
            }
            for (int i = 0; i < user_guess.Length; i++)
            {
                for (int j = 0; j < code.Length; j++)
                {
                    if (user_guess[i] == code[j])
                    {
                        code[j] = peg_color.Empty; // to prevent duplicate colors from double counting
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
            }
            else {
                Console.WriteLine($"Same place and color: {same_place_and_color}");
                Console.WriteLine($"Same color: {same_color}");
            }
        }

        public bool is_game_over()
        {
            return num_tries <= 0;
        }
    }
}