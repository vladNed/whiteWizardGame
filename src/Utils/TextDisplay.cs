using System;
using System.IO;
using System.Threading;

namespace WhiteWizard{

   public class TextDisplay{

        #region Variables
        private static string[,] textSplit;
        private static string[] loadedText;
        private static char[] separators = new char[]{' '};
        #endregion
        #region Text load/display
        private static void LoadText(string path){

            //load the text from the .txt document into the class
            int textLines = File.ReadAllLines(path).Length;
            loadedText = new string[textLines];
            loadedText = File.ReadAllLines(path);

            //Split the words on lines and add it to the array
            textSplit = new string[loadedText.Length,20];

            for(int row = 0; row<loadedText.Length;row++){

                string aux = loadedText[row];         
                string[] auxArray = aux.Split(separators,StringSplitOptions.RemoveEmptyEntries);
                if(auxArray.Length > 20){
                    break;
                } else {
                    for(int column = 0; column<auxArray.Length;column++){ 
                        textSplit[row,column] = auxArray[column];
                    }
                }
            };
        }
        public void DisplayText(string path){

            //Load the text first
            LoadText(path);

            //Save the coordinates for the cursor
            int x = Console.CursorTop;
            int y = Console.CursorLeft;

            //Start Writing
            for(int row = 0; row < textSplit.GetLength(0); row++){
                for(int column = 0; column < textSplit.GetLength(1); column++){
                    if(textSplit[row,column] != null){
                        Thread.Sleep(200);
                        Console.Write(textSplit[row,column]+" ");
                    } else {
                        break;
                    }
                }
                x++;
                Console.SetCursorPosition(y,x);
            }
        }
        #endregion
        #region Dialog load/display
        
        #endregion

    }
}