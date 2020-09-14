using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Player
    {
        public int health;
        public int damage;
    }

    struct Item
    {
        public int statBoost;
    }
    class Game
    {
        bool _gameOver = false;
        Player _player1;
        Player _player2;
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
            _player1.health = 100;
            _player1.damage = 5;

            _player2.health = 100;
            _player2.damage = 5;
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
                _player1.damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player1.damage += dagger.statBoost;
            }
            Console.WriteLine("Player 1");
            PrintStats(_player1);

            GetInput(out input, "LongSword", "Dagger", "Hurry and pick a weapon!");

            if (input == '1')
            {
                _player2.damage += longSword.statBoost;
            }
            else if (input == '2')
            {
                _player2.damage += dagger.statBoost;
            }
            Console.WriteLine("Player 2");
            PrintStats(_player2);

        }

        public void PrintStats(Player player)
        {
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Damage: " + player.damage);
        }


        //Performed once when the game begins
        public void Start()
        {
            
        }

        //Repeated until the game ends
        public void Update()
        {
            InitializedPlayers();
            InitializedItems();
            EquiptItems();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
