using System;
using System.Collections.Generic;

namespace src.Engine
{
    public class Inventory
    {
        #region Props
        private Dictionary<int,string> inventory;
        private int maxItems;
        #endregion

        //Constructor
        public Inventory(int _maxItems){
            this.maxItems = _maxItems;
            this.inventory = new Dictionary<int,string>(maxItems);
        }

        #region Getters/Setters
        public string GetInventoryItem(int key){
            return inventory[key];
        }
        public void RemoveItem(int key){
            inventory.Remove(key);
        }
        public int GetLastItem(){
            return inventory.Count;
        }
        public void SetInventoryItem(int key, string value){
            if(inventory.ContainsKey(key)){
               if(inventory[key]==value){
                   //Item is already in the inventory
               } else {
                   inventory[key] = value;
               }
            }
        }
        #endregion

    }
}