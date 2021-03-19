using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            List<Card> list = new List<Card>();
            List<Card> hand = new List<Card>();
            
            void GenerateDeck()
            {
                for (int i = 2; i < 15; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        list.Add(new Card{number = i, type = (Type)j});
                    }
                }
                for (int i = 2; i < 15; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        list.Add(new Card{number = i, type = (Type)j});
                    }
                }
            }
            void DrawHand()
            {
                int line = 0;
                for (int i = 0; i < 15; i++)
                {
                    int num = random.Next(0, list.Count);
                    if (Math.Floor(i / 8f) > line)
                    {
                        line++;
                        Console.WriteLine("");
                    }
                    Console.Write($"{list[num].Value} of {list[num].type} ({i + 1}) | ");
                    hand.Add(list[num]);
                    list.RemoveAt(num);
                }
            }
            
            void ShowHand()
            {
                int line = 0;
                for (int i = 0; i < hand.Count; i++)
                {
                    if (Math.Floor(i / 8f) > line)
                    {
                        line++;
                        Console.WriteLine("");
                    }
                    Console.Write($"{hand[i].Value} of {hand[i].type} ({i + 1}) | ");
                }
            }
            Card Draw()
            {
                int num = random.Next(0, list.Count);
                Card card = list[num];
                list.RemoveAt(num);
                return card;
            }

            GenerateDeck();
            DrawHand();

            while (true)
            {
                if(Console.ReadLine() == "end")
                    return;
                Console.Clear();
                hand.RemoveAt(random.Next(0, hand.Count));
                hand.Add(Draw());
                ShowHand();
            }
        }
    }
}

public struct Card
{
    public int number;

    public string Value
    {
        get
        {
            if (number <= 10)
                return number.ToString();
            switch (number)
            {
                case 11:
                    return "Jack";
                case 12:
                    return "Queen";
                case 13:
                    return "King";
                case 14:
                    return "Ace";
            }

            return "error in value getter!!";
        }
    }

    public Type type;
}

public enum Type
{
    Spades,
    Hearts,
    Clubs,
    Diamonds
}