using System;
using System.IO;

namespace MyApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            int credits = 50;

            MainMenu(ref credits);


        }

        public static void MainMenu(ref int credits) // ask user what game they want to play
        {
            DisplayGame();
            int userInput = GetGameChoice();

            while (credits > 0 && credits < 300)
            {

                if (credits <= 0)
                {
                    System.Console.WriteLine("You lose :(");
                }

                else if (credits >= 300)
                {
                    System.Console.WriteLine("YOU WIN!!!!");
                }

                while (userInput <= 3)
                {
                    if (userInput == 1)
                    {
                        TheForce(ref credits);
                    }

                    else if (userInput == 2)
                    {
                        Blasters(ref credits);
                    }
                    else if (userInput == 3)
                    {
                        ScoreBoard(ref credits);
                    }
                }
            }

        }

        public static void DisplayGame() // Displays menu options
        {
            Console.Clear();
            System.Console.WriteLine("Enter 1 to play THE FORCE");
            System.Console.WriteLine("Enter 2 to play BLASTERS");
            System.Console.WriteLine("Enter 3 to view the scoreboard");

        }

        public static int GetGameChoice() // reads user choice
        {
            int gameChoice = int.Parse(Console.ReadLine());

            while (gameChoice < 1 || gameChoice > 3)
            {
                System.Console.WriteLine("Please Enter a number 1-3");
                gameChoice = int.Parse(Console.ReadLine());
            }
            return gameChoice;
        }

        public static void TheForceStartUp() // Instructions for the force
        {

            System.Console.WriteLine("You are now about to play The Force. ");
            System.Console.WriteLine("hit enter to continue");
            Console.ReadLine();
            Console.Clear();
            System.Console.WriteLine("In this game Yoda will lay out a row of 10 cards, with one random card showing");
            System.Console.WriteLine("You(Luke Skywlker) must guess whether the next card will be over or under the previous card \n amount");
            System.Console.WriteLine("You must guess at least 5 card amounts correctly to not lose credits");
            System.Console.WriteLine("If you guess 7-9 correctly you coins will be doubled \nIf you guess 10 correctly they will be tripled");
            System.Console.WriteLine("IMPORTANT: Aces are always the lowest card");
            System.Console.WriteLine("Enter 1 to continue");


        }

        public static int TheForce(ref int credits) // Starts game
        {
            TheForceStartUp();
            int userInput = int.Parse(Console.ReadLine());

            if (userInput == 1)
            {
                int betAmount = 0;

                if (credits <= 0)
                {
                    System.Console.WriteLine("you do not have enough credits :(");
                    MainMenu(ref credits);
                }
                else if (credits >= 0)
                {
                    System.Console.WriteLine("enter amount you would like to bet");
                    betAmount = int.Parse(Console.ReadLine());
                    Console.Clear();
                    credits -= betAmount;
                }

                PlayTheForce(ref credits, betAmount);
            }
            else if (userInput == 2)
            {
                MainMenu(ref credits);
            }
            else
            {
                System.Console.WriteLine("invalid");
            }
            return credits;



        }

        public static int PlayTheForce(ref int credits, int betAmount) // Makes deck of cards
        {
            string[] suit = { "of clubs ", "of diamonds", "of hearts", "of spades" };
            string[] rank = { "Ace", "Two", "Three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "king", "queen" };
            string[] deck = new string[52];
            int count = 0;
            int userGuess = 0;
            int cardNumOne = 0;

            for (int i = 0; i < rank.Length; i++)
            {
                for (int j = 0; j < suit.Length; j++)
                {
                    deck[count] = rank[i] + suit[j];
                    count++;
                }
            }

            for (int i = 0; i < 11; i++)
            {
                ShownCards(userGuess);

                if (userGuess == 0)
                {
                    Random rnd = new Random();
                    cardNumOne = rnd.Next(deck.Length);
                }

                Random rndm = new Random();
                int cardNumTwo = rndm.Next(deck.Length);

                System.Console.WriteLine(deck[cardNumOne]);
                System.Console.WriteLine("Enter 1 if you think the next card will be higher");
                System.Console.WriteLine("Enter 2 if you think the next card will be lower");
                int userInput = int.Parse(Console.ReadLine());

                if (userInput == 1) // determines if user choice of higher is correct or incorrect
                {
                    if (cardNumOne < cardNumTwo)
                    {
                        System.Console.WriteLine("That is CORRECT! ");
                        userGuess++;
                        cardNumOne = cardNumTwo;

                        if (userGuess == 10)
                        {
                            System.Console.WriteLine("Amazing Job!!!!");
                            credits += betAmount * 3;
                            System.Console.WriteLine("Would you like to play again?");
                            TheForce(ref credits);
                        }

                    }
                    else if (cardNumOne > cardNumTwo)
                    {
                        System.Console.WriteLine("Sorry, INCORRECT GUESS :(");
                        GetGuesses(userGuess, betAmount, ref credits);
                        System.Console.WriteLine("Would you like to play again?");
                        TheForce(ref credits);
                    }
                }
                else if (userInput == 2) // determines if user choice of lower is correct or incorrect
                {
                    if (cardNumOne > cardNumTwo)
                    {
                        System.Console.WriteLine("That is CORRECT! ");
                        userGuess++;
                        cardNumOne = cardNumTwo;

                        if (userGuess == 10)
                        {
                            System.Console.WriteLine("Amazing Job!!!!");
                            credits += betAmount * 3;
                            System.Console.WriteLine("Would you like to play again?");
                            TheForce(ref credits);
                        }

                    }
                    else if (cardNumOne < cardNumTwo)
                    {

                        System.Console.WriteLine("Sorry, INCORRECT GUESS :(");
                        GetGuesses(userGuess, betAmount, ref credits);
                        System.Console.WriteLine("Would you like to play again?");
                        TheForce(ref credits);

                    }

                }
                else  // *extra* subtracts points for invalid input
                {
                    System.Console.WriteLine("Invalid! -1 point ");
                    credits -= betAmount - 1;
                }

            }
            return credits;
        }


        public static void ShownCards(int userGuess) // *extra* shows cards laying face down
        {
            for (int i = 11; i > userGuess; i--)
            {
                System.Console.Write(" [] ");
            }
            System.Console.WriteLine();
        }


        public static int GetGuesses(int userGuess, int betAmount, ref int credits) // determines credits earned for amount of correct correct guesses
        {
            if (userGuess == 1 || userGuess == 2 || userGuess == 3 || userGuess == 4)
            {
                System.Console.WriteLine("Sorry, you lose :(");
            }
            else if (userGuess == 5 || userGuess == 6)
            {
                System.Console.WriteLine("Not terrible, could be better");
                credits += betAmount;
            }
            else if (userGuess == 7 || userGuess == 8 || userGuess == 9)
            {
                System.Console.WriteLine("Good job!");
                System.Console.WriteLine("You get DOUBLE POINTS!!!");
                credits += betAmount * 2;
            }
            else if (userGuess == 10)
            {
                System.Console.WriteLine("YOU WIN!!!!!!");
                credits += betAmount;
            }
            return credits;
        }

        public static void BlastersStartUp() // Instructions to play blasters
        {
            System.Console.WriteLine("You are now about to play Blasters. ");
            System.Console.WriteLine("hit enter to continue");
            Console.ReadLine();
            Console.Clear();


            System.Console.WriteLine("Game explanation: ");
            System.Console.WriteLine("Yoda will shoot blaster, you can dodge or deflect them ");
            System.Console.WriteLine("You must enter at least 20 credits to start; Each dodge is worth 5 point, Each deflection is worth 10");
            System.Console.WriteLine("To exit game Enter 3");
            System.Console.WriteLine("Select 1 to continue");


        }

        static int Blasters(ref int credits) // starts blasters game

        {

            BlastersStartUp();
            int userInput = int.Parse(Console.ReadLine());

            if (userInput == 1) // check to see if user has enough credits to play 
            {
                int points = 15;
                int betAmount = 0;

                if (credits < 20)
                {
                    System.Console.WriteLine("You do not have enough credits :(");
                    MainMenu(ref credits);
                }

                else if (credits >= 20)
                {
                    System.Console.WriteLine("Enter credits:");
                    betAmount = int.Parse(Console.ReadLine());

                    if (betAmount < 20)
                    {
                        System.Console.WriteLine("You must bet at least 20 credits");
                        Console.Clear();
                        System.Console.WriteLine("Enter credits:");
                        betAmount = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        credits -= betAmount;
                    }

                }
                while (points > 0 && points < 40) //allows user to play while they have enough points
                {

                    System.Console.WriteLine("Points: " + points);
                    Console.ReadLine();



                    System.Console.WriteLine("BLASTERS INCOMING!!"); //possible extra
                    System.Console.WriteLine("Enter 1 to dodge");
                    System.Console.WriteLine("Enter 2 to deflect");
                    int userPick = int.Parse(Console.ReadLine());

                    if (userPick == 1) // if the user dodges this determines whether they were hit or not and adds or subtracts points
                    {

                        Random rnd = new Random();
                        int number = rnd.Next(2);

                        if (number == 0)
                        {
                            System.Console.WriteLine("you were hit");
                            points -= 5;
                        }
                        else if (number == 1)
                        {
                            System.Console.WriteLine("you dodge this one");
                            points += 5;
                        }

                    }
                    else if (userPick == 2) // this will determine whether a deflections was successful and add or subtract points
                    {
                        Random rnd = new Random();
                        int number = rnd.Next(10);

                        if (number == 1)
                        {
                            System.Console.WriteLine("Nice deflect");
                        }
                        else if (number == 2)
                        {
                            System.Console.WriteLine("You deflected this one ;)");
                        }
                        else if (number == 3)
                        {
                            System.Console.WriteLine("Great Job! Keep Going!!");
                        }
                        else
                        {
                            System.Console.WriteLine("You got HIT!! -5 points");
                            points -= 10;
                        }

                    }
                    else
                    {
                        System.Console.WriteLine("invalid choice");
                    }

                    if (points <= 0)
                    {
                        System.Console.WriteLine("Sorry, You lost");
                        System.Console.WriteLine("Would you like to plat again");

                    }
                    if (points >= 40)
                    {
                        System.Console.WriteLine("you win!!!");
                    }


                }

            }
            else if (userInput == 2)
            {
                MainMenu(ref credits);
            }

            else
            {
                System.Console.WriteLine("Invalid");
            }
            return credits;

        }

        public static void ScoreBoard(ref int credits) // shows current credits
        {
            System.Console.WriteLine(credits);
            System.Console.WriteLine("select enter to continue");
            Console.ReadKey();
            MainMenu(ref credits);
        }
    }
}
