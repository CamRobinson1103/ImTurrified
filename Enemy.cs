using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy
    {
        private int _slimeHealth;
        private int _slimeDamage;
        private int damageVal;

        public Enemy()
        {
            _slimeHealth = 3;
            _slimeDamage = 5;

        }


        public Enemy (int healthVal, int damageVal)
        {
            _slimeHealth = healthVal;
            _slimeDamage = damageVal;
        }

        public bool GetIsAlive()
        {
            return _slimeDamage > 0;
        }

        public void Attack(Enemy player)
        {
            player.TakeDamage(_slimeDamage);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: Slime");
            Console.WriteLine("Health: " + _slimeHealth);
            Console.WriteLine("Damage: " + _slimeDamage);
        }

        private void TakeDamage(int _slimeDamage)
        {
            if (GetIsAlive())
            {
                _slimeHealth -= damageVal;
            }
            Console.WriteLine("Slime took " + _slimeDamage + " damage!!!");
        }
    }
}
