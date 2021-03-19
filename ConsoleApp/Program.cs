using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Card> list = new List<Card>();
            Random random = new Random();
            for (int i = 1; i < 14; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    list.Add(new Card{number = i, type = (Type)j});
                }
            }

            int iterations = list.Count;
            while (true)
            {
                if(Console.ReadLine() == "end")
                    return;
                int num = random.Next(0, list.Count);
                Console.Write($"{list[num].Value} of {list[num].type}");
                list.RemoveAt(num);
            }
            for (int i = 0; i < iterations; i++)
            {
                int num = random.Next(0, list.Count);
                Console.Write($"{list[num].number} of {list[num].type} ({i + 1})  ");
                list.RemoveAt(num);
            }
            
            Console.Write("hi: ");
            Console.WriteLine("i'm " + Console.ReadLine());
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