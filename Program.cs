using System;

namespace mastermind
{
    public class MainClass
    {
        public static void Main()
        {
            Game game_inst = new Game(10);
            while(!game_inst.is_game_over())
            {
                game_inst.guess_code(); 
                game_inst.compare();
            }
        }
    }
}
