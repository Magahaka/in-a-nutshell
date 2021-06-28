using System;
using System.Collections.Generic;
using System.Linq;

namespace LanguageBasics
{
    class Program
    {
        static string val = "oldValue";
        static ref string GetValue() => ref val;

        static void Main(string[] args)
        {
            int minutes = 330;
            double hours = TimeSpan.FromMinutes(minutes).TotalHours;

            List<int> list = null;

            //bool test = list.Any(e => e == 1);

            bool value = new DateTime(2021, 06, 28, 0, 0, 0).TimeOfDay == TimeSpan.Zero ? true : false;

            int @int = 20;
            Console.WriteLine(@int.ToString());

            Product product = new Product();

            Product @Product = new Product();

            Product.Id = 1;

            Console.WriteLine
            
            ("test");

            // ---------------------------
            Panda panda1 = new Panda("Po");

            Panda panda2 = new Panda("Poo");
            Console.WriteLine(Panda.Population);
            panda1 = null;
            Console.WriteLine(Panda.Population);

            // ---------------------------
            int x = 1234;
            long y = x; // implicit
            short z = (short)x; // explicit

            int a = 1_000_000;

            int c = int.MaxValue;
            c++;
            Console.WriteLine(c);

            int ab = unchecked(a * c);

            var matrix1 = new int[,]
            {
                { 0,1,2 },
                { 3,4,5 },
                { 6,7,8 }
            };

            var matrix2 = new int[][]
            {
                new int[] { 0,2,3 },
                new int[] { 4,6,7 },
                new int[] { 9,11, 12 }
            };

            // (none), ref, in, out

            // passing parameters by value

            int ar = 8;
            Foo(ar);
            Console.WriteLine(ar);

            // ref

            int bar = 8;
            FooRef(ref bar);
            Console.WriteLine(bar);

            string first = "Labas";
            string second = "Rytas";
            Swap(ref first, ref second);
            Console.WriteLine(first.ToString() + " " + second.ToString());

            // out

            Split("Stevie Ray Vaughan", out string va, out _);
            Console.WriteLine(va);
            //Console.WriteLine(ba);

            // in
            int ara = 10;
            Testing(in ara);
            Console.WriteLine(ara);

            // optional parameters
            Optional(x: 3, y: 4);

            // ref locals and ref returns

            ref string valRef = ref GetValue();
            valRef = "New Value";
            Console.WriteLine(val);

            // null operators

            int? s1 = null;
            if (s1 == null)
            {
                s1 = 1;
            }

            // change to:
            s1 = null;
            s1 ??= 2;

            // switch patterns and expressions
            int nr = 3;
            int sum = 0;
            switch (nr)
            {
                case 1:
                    sum += 25;
                    break;
                case 2:
                    sum += 25;
                    goto case 1;
                case 3:
                    sum += 25;
                    goto case 2;
                default:
                    break;
            }

            bool TorF = true;
            switch (TorF)
            {
                case bool b when b == true:
                    Console.WriteLine("True");
                    break;
                default:
                    break;
            }

            // expressions

            int cardNumber = 2;
            string cardName = cardNumber switch
            {
                13 => "King",
                12 => "Queen",
                11 => "Jack",
                _ => "Pip card"
            };

            // goto statement

            if (cardNumber == 2)
            {
                goto Found;
            }

            Found:
                Console.WriteLine("Found the nr. 2 card");
        }

        

        static void Optional(int x = 1, int y = 2)
        {
            Console.WriteLine(x + " " + y);
        }

        static void Testing(in int x)
        {
            Console.WriteLine(x);
        }

        static void Split(string name, out string firstNames, out string lastName)
        {
            int i = name.LastIndexOf(' ');
            firstNames = name.Substring(0, i);
            lastName = name.Substring(i + 1);
        }

        static void Foo(int p)
        {
            p = p + 1;
            Console.WriteLine(p);
        }

        static void FooRef(ref int p)
        {
            p += 1;
            Console.WriteLine(p);
        }

        static void Swap(ref string first, ref string second)
        {
            var temp = second;
            second = first;
            first = temp;
        }
    }

    class Product
    {
        public int Id { get; set; }
    }

    class Panda
    {
        public string Name { get; set; }
        internal static int? Population { get; set; } = 0;

        public Panda(string name)
        {
            Name = name;
            Population += 1;
        }
    }
}
