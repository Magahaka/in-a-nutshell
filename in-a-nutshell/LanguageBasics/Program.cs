using System;

namespace LanguageBasics
{
    class Program
    {
        static string val = "oldValue";
        static ref string GetValue() => ref val;

        static void Main(string[] args)
        {
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
