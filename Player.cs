using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        public Player()
        {
            health = 100;
            damage = 10;
        }
        public Player(int healthVal, int damageVal)
        {
            health = healthVal;
            damage = damageVal;
        }
        public int health;
        public int damage;
    }
}
