using System;

namespace _021Lab_Gdr {
    public class MainMenu {
        public MainMenu() {
            
        }

        public void initialiseMenu() {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2)-5,0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Role Playing Game V0.6");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}