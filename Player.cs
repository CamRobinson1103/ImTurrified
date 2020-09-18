using System;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        private int _baseDamage;
        private int _totalDamage;
        private Item[] _inventory;
        private Item _currentWeapon;
        private Item _hands; 

        public Player()
        {
            _inventory = new Item[3];
            _health = 100;
            _baseDamage = 10;
            _hands.name = "These God-given hands";
            _hands.statBoost = 0;
        }

        public Player(string nameVal, int healthVal, int damageVal, int InventorySize)
        {
            _name = nameVal;
            _health = healthVal;
            _baseDamage = damageVal;
            _inventory = new Item[InventorySize];
            _hands.name = "These God-given hands";
            _hands.statBoost = 0;

        }

        public Item[] GetInventory()
        {
            return _inventory;
        }


        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public bool Container(int itemIndex)
        {
            if(itemIndex > 0 && itemIndex <4)
            {
                return true;
            }
            return false;
        }

        public void EquipItem(int itemIndex)
        {
            if (Container(itemIndex) == true)
            {
                _currentWeapon = _inventory[itemIndex];
            }

            
        }

        public string GetName()
        {
            return _name;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public void UnequipItem(int itemIndex)
        {
            _currentWeapon = _hands;
        }

        public void Attack(Player enemy)
        {
            int totalDamage = _baseDamage + _currentWeapon.statBoost;
            enemy.TakeDamage(_totalDamage);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _baseDamage);
        }

        private void TakeDamage(int damageVal)
        {
            if (GetIsAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + " took " + damageVal + " damage!!!");
        }
    }
}
