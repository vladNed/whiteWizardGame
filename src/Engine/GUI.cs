using System;

namespace WhiteWizard{

    class GUI: TextUtil{

        //import TextUtil so text an be managed


        //The show method displays the whole GUI to the player
        public void Show(Player player){
            
            Console.WindowWidth = 121;
            Console.WindowHeight = 30;

            //GUI
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Reset();
            Console.Write(
@"|----------------------------------------------------------------------------------------------------------------------|
|    Health:{0}/{1}                 |                 XP:{2}/{3}                 |         Name:{4}  Items:{5}/{6}   
|----------------------------------------------------------------------------------------------------------------------|
|    Command:                                                                                                          |
|----------------------------------------------------------------------------------------------------------------------|",
                    player.GetHealth(),
                    player.GetMaxHP(),
                    player.GetXP(),
                    player.GetMaxXP(),
                    player.GetName(),
                    player.GetCurrentItems(),
                    player.GetItems());
        
            Console.SetCursorPosition(119,1);
            Console.Write("|");
        }

        //Sets the cursor position on the GUI part where the text can be
        //written
        public void SetWrite(){
            Console.SetCursorPosition(5,7);
            Reset();
        }

        public string SetCommand(){
            Console.SetCursorPosition(14,3);
            Reset();
            ClearCommandLine();
            string command = Console.ReadLine().ToLower();
            return command;
        }
    }
}