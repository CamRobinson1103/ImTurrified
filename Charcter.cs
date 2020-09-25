using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Character
    {
        private float _health;
        private string _name;
        protected float _damage;


        public Character()
        {
            _health = 100;
            _name = "Yuusha";
            _damage = 10;
        }

        public Character(float healthVal, string nameVal, float damageVal)
        {
            _health = healthVal;
            _name = nameVal;
            _damage = damageVal;
        }

        public virtual void Attack(Character enemy)
        {
            enemy.TakeDamage(_damage);
        }

        public virtual void TakeDamage(float damageVal)
        {
            _health -= damageVal;
            if(_health < 0)
            {
                _health = 0;
            }
        }

       

    }
}
