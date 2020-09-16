using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Enemy
    {
        private int _health;
        private int _damage;

        public Enemy()
        {
            _health = 3;
            _damage = 1;

        }


        public Enemy (int healthVal, int damageVal)
        {
            _health = healthVal;
            _damage = damageVal;
        }
    }
}
