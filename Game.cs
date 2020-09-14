using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    

    struct Item
    {
        public int statBoost;
    }
    class Game
    {
        bool _gameOver = false;
        Player _player1 = new Player(20,150);
        Player _player2 = new Player(150,20);
        Item longSword;
        Item dagger;

        //Run the game
        public void Run()
        {
            Start();

            while(_gameOver == false)
            {
                Update();
            }

            End();
        }

        public void InitializedPlayers()
        {
            _player1._health = 100;
            _player1._damage = 5;

            _player2._health = 100;
            _player2._damage = 5;
        }

        public void InitializedItems()
        {
            longSword.statBoost = 15;
            dagger.statBoost = 10;
        }
        //Displays Options
        public void GetInput (out char input, string option1, string option2, string query)
        {
            //Prints description
            Console.WriteLine(query);
            //Prints options
            Console.WriteLine("[1]" + option1);
            Console.WriteLine("[2]" + option2);
            Console.WriteLine("> ");

            input = ' ';
            //Loops until recieved
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if(input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid Input");
                }
       
            }

            input = Console.ReadKey().KeyChar;
        }
        public void EquiptItems()
        {
            //Gets input from player 1
            char input;
            GetInput(out input, "LongSword", "Dagger", "Hurry and pick a weapon!");
            //Equipts item based on input value
            if(input == '1')
            {
                _player1._damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player1._damage += dagger.statBoost;
            }
            Console.WriteLine("Player 1");
            PrintStats(_player1);

            GetInput(out input, "LongSword", "Dagger", "Hurry and pick a weapon!");

            if (input == '1')
            {
                _player2._damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player2._damage += dagger.statBoost;
            }
            Console.WriteLine("Player 2");
            PrintStats(_player2);
        }
        
        

        public void StartBattle()
        {
            Console.WriteLine("Move along now!");

            while (_player1._health > 0 && _player2._health > 0)
            {
                Console.WriteLine("Player 1");
                PrintStats(_player1);
                Console.WriteLine("Player 2");
                PrintStats(_player2);

                char input;
                GetInput(out input, "Attack", "Beg for mercy", "Your turn Player 1");

                if(input == '1')
                {
                    _player2._health -= _player1._damage;
                    Console.WriteLine("Player 2 took " + _player1._damage + " _damage");
                }
                else
                {
                    Console.WriteLine("I BEG FOR MERCY!!!");
                }

                GetInput(out input, "Attack", "Beg for mercy", "Your turn Player 2");

                if (input == '1')
                {
                    _player1._health -= _player2._damage;
                    Console.WriteLine("Player 1 took " + _player2._damage + " _damage");
                }
                else
                {
                    Console.WriteLine("I BEG FOR MERCY!!!");
                }
                Console.Clear();
            }
            if(_player1._health> 0 )
            {
                Console.WriteLine("Player 1 is vinegaritourious!!");
            }
            else
            {
                Console.WriteLine("Player 2 is vinegaritourious!!");
            }
            _gameOver = true;



        }


        public void PrintStats(Player player)
        {
            Console.WriteLine("Health: " + player._health);
            Console.WriteLine("Damage: " + player._damage);
        }


        //Performed once when the game begins
        public void Start()
        {
            InitializedPlayers();
            InitializedItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            
            EquiptItems();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
