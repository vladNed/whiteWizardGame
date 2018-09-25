using System;

namespace WhiteWizard{
    class PrologueLevel{

        private static TextDisplay textDisplay = new TextDisplay();
        private static Controls controls = new Controls();
        public static void Start(){
            PrologueText();
        }

        private static void PrologueText(){
            textDisplay.DisplayText(@"C:\Users\nedvl\Desktop\WhiteWizard\src\Drawings\prologueText.txt");
            controls.showOnScreenCommands();
        }
    }
}