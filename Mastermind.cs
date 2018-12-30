using System;

namespace mastermind
{
    public class Game
    {
        public int num_tries{ get; set; } = 10;
        public bool game_over { get; } = false;
        private peg_color[] code;
        private enum peg_color { Red, Blue, Green, Yellow, Pink, White, Black, Empty };
        private const int CODE_LENGTH = 4;

        // At declaration, generate the code to be guessed by the user.
        public Game()
        {
            
        }
        
        // Generates a random code of desired code length
        private peg_color[] generate_code()
        {
            
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