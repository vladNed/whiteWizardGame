using System;

namespace WhiteWizard{
    class GameEngine{

        static GUI gui = new GUI();

        public static void Start(string command,int level,Player player){

            if(level == 0){
                switch(command){
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
            } else if (level == 1){
                switch(command){
                    case "continue":
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Start("continue",1,player);
                        break;
                }
            } else if (level == 2){
                switch(command){
                    
                }
            }

        }

        //Load Level method
        public static void LoadLevel(Player player){
            LoadGUI(player);
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

    }
}