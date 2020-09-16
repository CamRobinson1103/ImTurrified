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
        private bool _gameOver = false;
        private Player _player1;
        private Player _player2;
        private Item _longSword;
        private Item _dagger;

        //Run the game
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }

            End();

        }

        public void InitializeItems()
        {
            _longSword.statBoost = 15;
            _dagger.statBoost = 10;
        }

        //Displays two options to the player. Outputs the choice of the two options
        public void GetInput(out char input, string option1, string option2, string query)
        {
            //Print description to console
            Console.WriteLine(query);
            //print options to console
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.Write("> ");

            input = ' ';
            //loop until valid input is received
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }

        //Equip items to both players in the beginning of the game
        public void SelectItem(Player player)
        {
            //Get input for player one
            char input;
            GetInput(out input, "Longsword", "Dagger", "OI! Hurry and choose a weapon!");
            //Equip item based on input value
            if (input == '1')
            {
                player.EquipItem(_longSword);
            }
            else if (input == '2')
            {
                player.EquipItem(_dagger);
            }
        }

        public Player CreateCharacter()
        {
            Console.WriteLine("Watu isu ya neimu?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10);
            SelectItem(player);
            return player;
        }

        public void ClearScreen()
        {
            Console.WriteLine("Press any key to continue");
            Console.Write("> ");
            Console.ReadKey();
            Console.Clear();
        }

        public void StartBattle()
        {
            ClearScreen();
            Console.WriteLine("Now GO!");

            while (_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                //print player stats to console
                Console.WriteLine("Player1");
                _player1.PrintStats();
                Console.WriteLine("Player2");
                _player2.PrintStats();
                //Player 1 turn start
                //Get player input
                char input;
                GetInput(out input, "Attack", "BEG FOR MERCY", "Your turn Player 1");

                if (input == '1')
                {
                    _player1.Attack(_player2);
                }
                else
                {
                    Console.WriteLine("BEG FOR MERCY");
                }

                GetInput(out input, "Attack", "BEG FOR MERCY", "Your turn Player 2");

                if (input == '1')
                {
                    _player2.Attack(_player1);
                }
                else
                {
                    Console.WriteLine("BEG FOR MERCY");
                }
                Console.Clear();
            }
            if (_player1.GetIsAlive())
            {
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE!!!!!!!!!!!!!!!!!!!!!!! Player 1 wons");
            }
            else
            {
                Console.WriteLine("...woo Player 2 wins, I guess...");
            }
            ClearScreen();
            _gameOver = true;
        }


        //Performed once when the game begins
        public void Start()
        {
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            _player1 = CreateCharacter();
            _player2 = CreateCharacter();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {

        }
    }
}
