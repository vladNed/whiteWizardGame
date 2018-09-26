using System;
using src.Engine;

namespace WhiteWizard{
    class GameEngine{

        public static GUI gui = new GUI();
        public static Inventory inventory;

        public static void Start(string command,int level,Player player){

            if(level == 0){
                switch(command){
                    case "start":
                        LoadInventory(player.GetItems());
                        LoadGUI(player); 
                        LoadLevel1(player);
                        break;
                    case "controls":
                        break;
                    case "help":
                        break;
                    case "exit":
                        break;
                    default: break;
                }
            } else if (level == 1){
                switch(command){
                    case "continue":
                        LoadGUI(player);
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Start("continue",1,player);
                        break;
                }
            } 

        }

        //Load Level method
        public static void LoadLevel1(Player player){
            PrologueLevel.PrologueText();
            Start(gui.SetCommand(),1,player);
            PrologueLevel.PrologueDialog(player.GetColor());
            Start(gui.SetCommand(),1,player);

        }
        //Load the GUI method
        public static void LoadGUI(Player player){ 
            gui.Show(player);
            gui.SetWrite();
        }
        //Load the Inventory method
        public static void LoadInventory(int maxItems){
            inventory = new Inventory(maxItems);
        }

        public static void AddItemToInventory( string value,Player player){
            if(player.GetCurrentItems() < player.GetItems()){
                inventory.SetInventoryItem(player.GetCurrentItems(),value);
            } else {
                //dont do anything
            }
        }
    }
}