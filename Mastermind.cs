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
            
        }

        private peg_color[] guess() 
        {
            
        }

        private peg_color[] convert_to_peg(string[] guess)
        {
            
        }

        private void compare(peg_color[] guess)
        {
            
        }

        private void guess_accuracy(int same_place_and_color, int same_color)
        {
            
        }
    }
}