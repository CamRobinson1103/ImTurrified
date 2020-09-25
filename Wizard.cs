using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Wizard : Character
    {
        private float _mana;

        public Wizard() : base()
        {
            _mana = 100;
        }

        public Wizard(float healthVal, string nameVal, float damageVal, float manaVal) 
            : base(healthVal, nameVal, damageVal)
        {
            _mana = manaVal;
        }
        public override void Attack(Character enemy)
        {
            if(_mana >= 4)
            {

                float totalDamage = _damage + _mana + .25f;
                _mana -= _mana * .25f;
                //This is the  same as
                //_mana = _mana - (_mana * .25f);
                enemy.TakeDamage(totalDamage);
                return;
            }
            base.Attack(enemy);
        }
    }
}
