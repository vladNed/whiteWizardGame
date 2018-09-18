using System;
using System.Linq;
using System.Reflection;

namespace WhiteWizard{

    class Player{

        #region PlayerStats
        private string Name;
        private int Health;
        private int MaxHealth;
        private int XP;
        private int MaxXP;
        private string Class;
        private int Strength;
        private int Magic;
        private int Range;
        private int Items;
        private int CurrentItems;
        private ConsoleColor Color = new ConsoleColor();
        #endregion

        #region Constructor
        public Player(string _name, int _health,int _maxHP,int _xp,int _maxp,string _class, int _strength, int _magic, int _range, int _items, ConsoleColor color ){
            
            this.Name = _name;
            this.Health = _health;
            this.MaxHealth = _maxHP;
            this.XP = _xp;
            this.MaxXP = _maxp;
            this.Class = _class;
            this.Strength = _strength;
            this.Magic = _magic;
            this.Range = _range;
            this.Items = _items;
            this.Color = color;
            this.CurrentItems = 0;
        }
        public Player(){
            this.Name = "NoName";
            this.Health = 0;
        }
        #endregion

        #region Getters
        public string GetName(){
            return this.Name;
        }
        public int GetHealth(){
            return this.Health;
        }
        public string GetClass(){
            return this.Class;
        }
        public int GetStrength(){
            return this.Strength;
        }
        public int GetMagic(){
            return this.Magic;
        }
        public int GetRanged(){
            return this.Range;
        }
        public int GetItems(){
            return this.Items;
        }
        public int GetXP(){
            return this.XP;
        }
        public int GetMaxHP(){
            return this.MaxHealth;
        }
        public int GetMaxXP(){
            return this.MaxXP;
        }
        public int GetCurrentItems(){
            return this.CurrentItems;
        }
        #endregion

        #region Setters
        //TODO: Make the setters for the stats
        public void SetItems(int value){
            this.CurrentItems = value;
        }
        #endregion

        public string[] PlayerStats(){
            PropertyInfo[] _stats = typeof(Player).GetProperties();
            string[] _playerStats = new string[6];
            int i = 0;
            foreach(PropertyInfo prop in _stats){
                _playerStats[i] = prop.ToString();
                i++;
            }
            return _playerStats;
        }
    }
}