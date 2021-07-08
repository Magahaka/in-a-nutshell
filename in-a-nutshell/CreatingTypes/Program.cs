using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatingTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = default(DateTime?);
            var date1 = default(DateTime);

            var asd = Nullable.GetUnderlyingType(typeof(DateTime?));

            List<int> lisast = null;
            var aaaaa = lisast.FirstOrDefault();

            string bandom = string.Empty;
            var vava = bandom.ToLower();

            Test test = new Test(1, 10);

            ChangeReference(test);

            Console.WriteLine(test.Id + " " + test.Age);

            Console.WriteLine(Foo(2));

            Wine wine = new Wine(10, 1999);

            var rect = new Rectangle(3, 4);
            (_, var height) = rect;
            Console.WriteLine(height);

            Bunny b1 = new Bunny { Name = "Bo", LikesCarrots = true, LikesHumans = false };
            Bunny b2 = new Bunny("Bo") { LikesCarrots = true, LikesHumans = false };

            Stock stock = new Stock();
            stock.CurrentPrice = 10;
            Console.WriteLine(stock.Worth);

            Sentence s = new Sentence();
            Console.WriteLine(s[^1]);
            var a = s[..2];
        }

        static void ChangeReference(Test test)
        {
            test = null;
        }

        static int Foo(int x) => x * 2;
    }

    public class Sentence
    {
        string[] words = "The quick brown fox".Split();

        public string this[int indexer]
        {
            get => words[indexer];
            set => words[indexer] = value;
        }

        ~Sentence() => Console.WriteLine("Finalizing");

        public string this [Index index] => words[index];
        public string[] this [Range range] => words[range];
    }

    public class Stock
    {
        decimal currentPrice;

        public decimal CurrentPrice
        {
            get { return currentPrice; }
            set { currentPrice = value; }
        }

        public decimal Worth 
        {
            get => currentPrice * 2.15m;
            set => currentPrice = value * 0.9m;
        } 
    }

    class Bunny
    {
        public string Name;
        public bool LikesCarrots;
        public bool LikesHumans;

        public Bunny() { }
        public Bunny(string n) => (Name) = (n);
    }

    class Rectangle
    {
        public readonly float Width, Height;
        public Rectangle(float width, float height) => (Width, Height) = (width, height);

        public void Deconstruct(out float width, out float height)
        {
            width = Width;
            height = Height;
        }
    }

    class Wine
    {
        public decimal Price;
        public int Year;
        public Wine(decimal price) => Price = price;
        public Wine(decimal price, int year) : this(price) => Year = year;
    }

    class Test
    {
        public int Id { get; set; }
        public int Age { get; set; }

        public Test(int id, int age)
        {
            Id = id;
            Age = age;
        }
    }
}
