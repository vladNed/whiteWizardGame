using System;
using System.IO;

namespace WhiteWizard{
    class MainMenuScreen{

        #region Variables
        static TextUtil util = new TextUtil();
        static Controls control = new Controls();
        #endregion
        
        //The Show method displayes the main menu
        //where the player can select what it wants
        public static string Show(){
            
            string menuGraphics = File.ReadAllText(@"C:\Users\nedvl\Desktop\WhiteWizard\src\Drawings\menuDrawing.txt");

            //Display the MainMenu
            Console.Write(menuGraphics);
            util.DrawControl(23,10,ConsoleColor.Yellow,">");
            control.moveCursor(10,15);

            //Call the menu choice and return it to the Main method
            int x = Console.CursorTop;
            return MenuChoice(x);

        }

        //This method will see what part of the main menu was choosen
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