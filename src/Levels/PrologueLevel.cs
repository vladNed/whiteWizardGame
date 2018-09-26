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
            if(player.GetClass() == "warrior")
            {            
                Reset();
                CursorPosition();
                Console.Write("Pick up the ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("axe");
                Reset();
                Console.Write("?");

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
                
            }
            if(player.GetClass() == "hunter")
            {   
                Reset();
                Console.Write("Pick up the ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("bow&arrow");
                Reset();
                Console.Write("?");
                
                ItemsPick(player,"bow&arrow");

                Console.Write("Pick up the bottle of ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("water");
                Reset();
                Console.Write("?");

                ItemsPick(player, "water");

                Console.Write("Pick up the bag of");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("coins");
                Reset();
                Console.Write("?");

                ItemsPick(player,"coins");
            }       
            if(player.GetClass() == "mage"){
                
                Reset();
                Console.Write("Pick up your ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("staff");
                Reset();
                Console.Write("?");

                ItemsPick(player,"staff");
                
                Console.Write("Pick up the ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("book of spells");
                Reset();
                Console.Write("?");

                ItemsPick(player,"book of spells");
                
                Console.Write("Pick up the ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("mana potions");
                Reset();
                Console.Write("?");

                ItemsPick(player,"mana potions");
                
                Console.Write("Pick up the bag of");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("coins");
                Reset();
                Console.Write("?");

                ItemsPick(player,"coins");
              
            }
            if(player.GetClass() == "adventurer"){

                Reset();
                Console.Write("Pick up your");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(" travelling stick");
                Reset();
                Console.Write("?");
                
                ItemsPick(player,"travelling stick");

                Console.Write("Pick up the bag of");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" coins");
                Reset();
                Console.Write("?");
                
                ItemsPick(player,"coins");

                Console.Write("Pick up the ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(" meat");
                Reset();
                Console.Write("?");
                
                ItemsPick(player,"meat");

                Console.Write("Pick up the ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("knife");
                Reset();
                Console.Write("?");
                
                ItemsPick(player,"knife");

                Console.Write("Pick up the ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("blanket and flint stone");
                Reset();
                Console.Write("?");

                ItemsPick(player, "blanket and flint stone");    
            }
            controls.showOnScreenCommands();
        }
        #endregion

        public static void ItemsPick(Player player, string item){
            CursorPosition();
            do{
                commandLine = GameEngine.gui.SetCommand();
                commandLine.ToLower();
                switch(commandLine){
                    case "pick up":
                    case "yes":
                    case "ok":
                    case "sure":
                        GameEngine.AddItemToInventory(item,player);
                        SetCursorLast();
                        Console.Write("    *Hmmm I sure need this!*");
                        break;
                    case "no":
                    case "dont pick":
                    case "nope":
                        SetCursorLast();
                        Console.Write("   *O well I guess I don't need this.*");
                        break;
                    default: commandLine = "";
                        break;
                }

            }while(commandLine=="");
            Console.SetCursorPosition(5,GetPreviousTopCursor()+1);
        }

    }
}