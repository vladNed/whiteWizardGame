using System;
using System.IO;

namespace WhiteWizard{
    class MainMenuScreen{
        static TextUtil util = new TextUtil();
        static Controls control = new Controls();
        public static string Show(){
            
            string menuGraphics = File.ReadAllText(@"C:\Users\nedvl\Desktop\WhiteWizard\Drawings\menuDrawing.txt");

            //Display the MainMenu
            Console.Write(menuGraphics);
            util.DrawControl(23,10,ConsoleColor.Yellow,">");
            control.moveCursor(10,15);
            int x = Console.CursorTop;
            return MenuChoice(x);

        }

        private static string MenuChoice(int x){

            if(x == 10){
                return "start";
            }
            if(x == 11){
                return "controls";
            }
            if(x == 12){
                return "help";
            }
            if(x == 15){
                return "exit";
            }else{
                return null;
            }
        }
        
    }
}