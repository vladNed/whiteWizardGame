using System;
using System.IO;

namespace WhiteWizard{

    class TextDisplay{
        private static string[,] textSplit;
        private static string[] loadedText;

        public static void LoadText(string path){

            //load the text fromt the .txt document into the class
            int textLines = File.ReadAllLines(path).Length;
            loadedText = new string[textLines];

            //Split the words on lines and add it to the array
            textSplit = new string[loadedText.Length,100];

            for(int row = 0; row<loadedText.Length;row++){

                string aux = loadedText[row];
                string[] auxArray = aux.Split(new char[]{' ','.',','},StringSplitOptions.RemoveEmptyEntries);
                
                if(auxArray.Length > 100){
                    break;
                } else {
                    for(int column = 0; column<auxArray.Length;column++){
                        textSplit[row,column] = auxArray[column];
                    }
                }
            }
        }
    }
}