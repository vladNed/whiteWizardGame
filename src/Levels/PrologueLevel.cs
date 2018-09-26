using System;

namespace WhiteWizard{
    class PrologueLevel: TextUtil{

        #region Variables
        private static TextDisplay textDisplay = new TextDisplay();
        private static Controls controls = new Controls();
        public static string commandLine = "";
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

        public static void ProloguePacking(Player player){
            textDisplay.DisplayText(@"C:\Users\nedvl\Desktop\WhiteWizard\src\Drawings\prologuePacking.txt");
            if(player.GetClass() == "war")
            {            
                Reset();
                Console.Write("Pick up the ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("axe");
                Reset();
                Console.Write("?  ");

                ItemsPick(player,"axe");

                Console.Write("Pick up the bag of ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("coins");
                Reset();
                Console.Write("?  ");

                ItemsPick(player,"coins");

                Console.Write("Pick up a ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("bottle of water");
                Reset();
                Console.Write("?  ");

                ItemsPick(player,"bottle of water");

                Console.Write("Pick up the ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("map");
                Reset();
                Console.Write("?  ");

                ItemsPick(player,"map");
                
                //Each pick will move the item to inventory
            }       
        }
        #endregion

        public static void ItemsPick(Player player, string item){
            do{
                commandLine = GameEngine.gui.SetCommand();
                commandLine.ToLower();
                switch(commandLine){
                    case "pick up":
                    case "yes":
                    case "ok":
                    case "sure":
                        GameEngine.AddItemToInventory(item,player);
                        break;
                    case "no":
                    case "dont pick":
                    case "nope":
                        Console.WriteLine("O well i guess i dont need this");
                        break;
                    default: commandLine = "";
                        break;
                }
            }while(commandLine!="");
        }

    }
}