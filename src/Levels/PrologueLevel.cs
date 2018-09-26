using System;

namespace WhiteWizard{
    class PrologueLevel{

        #region Variables
        private static TextDisplay textDisplay = new TextDisplay();
        private static Controls controls = new Controls();
        #endregion

        #region Text and Dialog
        //Method to display text in the prologue level
        public static void PrologueText(){
            textDisplay.DisplayText(@"C:\Users\nedvl\Desktop\WhiteWizard\src\Drawings\prologueText.txt");
            controls.showOnScreenCommands();
        }

        //Method to display dialogue in prologue level
        public static void PrologueDialog(ConsoleColor playerColor){
            textDisplay.displayDialog(@"C:\Users\nedvl\Desktop\WhiteWizard\src\Drawings\prologueHyngwarDialog.txt",playerColor);
            controls.showOnScreenCommands();
        }

        public static void ProloguePacking(string playerClass){
            textDisplay.DisplayText(@"C:\Users\nedvl\Desktop\WhiteWizard\src\Drawings\prologuePacking.txt");
            if(playerClass == "war")
            {
                //Pick up axe,coins,water,map
                //Each pick will move the item to inventory
            }       
        }
        #endregion

    }
}