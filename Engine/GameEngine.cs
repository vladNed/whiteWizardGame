using System;

namespace WhiteWizard{
    class GameEngine{

        static GUI gui = new GUI();

        public static void Start(string genesisCommand,Player player){

            switch(genesisCommand){
                case "start": 
                    LoadLevel(player);
                    break;
                case "controls":
                    break;
                case "help":
                    break;
                case "exit":
                    break;
                default: break;
            }

        }

        //Load Level method
        public static void LoadLevel(Player player){
            LoadGUI(player);
            PrologueLevel.Start();
        }
        //Load the GUI method
        public static void LoadGUI(Player player){ 
            gui.Show(player);
            gui.SetWrite();
        }
        //Load the Inventory method

    }
}