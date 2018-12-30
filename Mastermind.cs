using System;

namespace mastermind
{
    public class Mastermind
    {
        public int num_tries{ get; set; } = 10;
        public bool game_over { get; } = false;
        private peg_color[] code;
        private enum peg_color { Red, Blue, Green, Yellow, Pink, White, Black, Empty };
        private const int CODE_LENGTH = 4;

        // At declaration, generate the code to be guessed by the user.
        public Mastermind()
        {
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

        // Performs the processes of the game
        public void play()
        {
            peg_color[] user_code;
            user_code = guess(); 
            compare(user_code);
            --num_tries;
        }

        private peg_color[] guess() 
        {
            string input;
            string [] guess = new string[CODE_LENGTH];

            do{
                Console.WriteLine($"You have {num_tries} tries left.\nPlease put spaces inbetween each" +
                                " color in you guess.\nGuess: ");
                input = Console.ReadLine();
                guess = input.Split(' ');
            }
            while(guess.Length != CODE_LENGTH);
            
            return convert_to_peg(guess);
        }

        private peg_color[] convert_to_peg(string[] guess)
        {
            peg_color[] enum_version = new peg_color[CODE_LENGTH];
            for (int i = 0; i < guess.Length; i++) 
            {
                switch(guess[i].ToLower())
                {
                    case "red": {
                        enum_version[i] = peg_color.Red;
                        break;
                    }
                    case "blue": {
                        enum_version[i] = peg_color.Blue;
                        break;
                    }
                    case "green": {
                        enum_version[i] = peg_color.Green;
                        break;
                    }
                    case "yellow": {
                        enum_version[i] = peg_color.Yellow;
                        break;
                    }
                    case "pink": {
                        enum_version[i] = peg_color.Pink;
                        break;
                    }
                    case "white": {
                        enum_version[i] = peg_color.White;
                        break;
                    }
                    case "black": {
                        enum_version[i] = peg_color.Black;
                        break;
                    }
                    default : {
                        enum_version[i] = peg_color.Empty;
                        break;
                    };
                }
            }
            return enum_version;
        }

        private void compare(peg_color[] guess)
        {
            
        }

        private void guess_accuracy(int same_place_and_color, int same_color)
        {
            
        }
    }
}