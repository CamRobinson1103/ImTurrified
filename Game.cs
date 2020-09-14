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
        Player _player1 = new Player("Ron", 101, 21);
        Player _player2 = new Player("Kam", 150,20);
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
        public void SelectItems()
        {
            //Gets input from player 1
            char input;
            GetInput(out input, "LongSword", "Dagger", "Hurry and pick a weapon!");
            //Equipts item based on input value
            if(input == '1')
            {
                _player1.EquipItem(longSword);
            }
            else if (input == '2')
            {
                _player1.EquipItem(dagger);
            }
            Console.WriteLine("Player 1");
            _player1.PrintStats();

            GetInput(out input, "LongSword", "Dagger", "Hurry and pick a weapon!");

            if (input == '1')
            {
                _player2.EquipItem(longSword);
            }
            else if (input == '2')
            {
                _player2.EquipItem(dagger);
            }
            Console.WriteLine("Player 2");
            _player2.PrintStats();
        }
        
        public void ClearScreen()
        {
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("> ");
            Console.ReadKey();
            Console.Clear();
        }

        public void StartBattle()
        {
            Console.WriteLine("Move along now!");

            while (_player1.GetIsAlive()  && _player2.GetIsAlive())
            {
                Console.WriteLine("Player 1");
                _player1.PrintStats();
                Console.WriteLine("Player 2");
                _player2.PrintStats();

                char input;
                GetInput(out input, "Attack", "Beg for mercy", "Your turn Player 1");

                if(input == '1')
                {
                    _player1.Attack(_player2);
                }
                else
                {
                    Console.WriteLine("I BEG FOR MERCY!!!");
                }

                GetInput(out input, "Attack", "Beg for mercy", "Your turn Player 2");

                if (input == '1')
                {
                    _player2.Attack(_player1);
                }
                else
                {
                    Console.WriteLine("I BEG FOR MERCY!!!");
                }
                Console.Clear();
            }
            if(_player1.GetIsAlive())
            {
                Console.WriteLine("Player 1 is vinegaritourious!!");
            }
            else
            {
                Console.WriteLine("Player 2 is vinegaritourious!!");
            }
            _gameOver = true;



        }


        


        //Performed once when the game begins
        public void Start()
        {
            InitializedItems();
        }

        //Repeated until the game ends
        public void Update()
        {

            SelectItems();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
