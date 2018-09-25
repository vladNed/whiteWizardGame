using System;

namespace WhiteWizard{

    class GUI{

        //import TextUtil so text an be managed
        static TextUtil util = new TextUtil();

        //The show method displays the whole GUI to the player
        public void Show(Player player){
            
            Console.WindowWidth = 121;
            Console.WindowHeight = 30;

            //GUI
            util.Reset();
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            
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
        }

        public string SetCommand(){
            Console.SetCursorPosition(3,14);
            string command = Console.ReadLine().ToLower();
            return command;
        }
    }
}