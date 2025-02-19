namespace Orai_0219
{
    internal class Program
    {
        static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            new Program().Run();
            Console.ReadLine();
        }

        void Run()
        {
            //Orai();
            Hazi1();
            Hazi2();
        }

        void Orai()
        {
            Tanulo tanulo1 = new Tanulo("🐈💨", 69, "Gyöngyös");
            for (int i = 0; i < 5; i++)
            {
                tanulo1.AddJegy((byte)rnd.Next(1, 6));
            }
            Console.WriteLine(tanulo1);
            Allat allat = new Allat("🦊", "Mi bomboclad!");
            Console.WriteLine(allat);
            Allat2 allat2 = new Allat2();
            Console.WriteLine(allat2);
        }

        void Hazi1()
        {
            Muvelet muvelet = new Muvelet(Beker<float>("Add meg az x értékét: "), Beker<float>("Add meg az y értékét: "));
            const int ismetlesSzam = 4;
            for (int i = 0; i < ismetlesSzam; i++)
            {
                Console.WriteLine($"{i + 1}/{ismetlesSzam}:");
                bool helyesOperator = false;
                while (!helyesOperator)
                {
                    try
                    {
                        muvelet.Kiszamol(Beker<char>("Add meg a műveletet (+, -, *, /): "));
                        helyesOperator = true;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                muvelet.EredmenytKiir();
                Console.WriteLine("Eredmény (manuálisan kiírva): " + muvelet.Eredmeny);
            }
        }

        void Hazi2()
        {
            Tomb<byte> tomb = new Tomb<byte>(Beker("Add meg a tömb méretét [10, 50]: ", "A tömb mérete csak 10 (inkluzív) és 50 (inkluzív) között lehet.", static (int ertek) => ertek is >= 10 and <= 50));
            tomb.Feltolt();
            Console.WriteLine("Rendezetlenül: " + tomb);
            tomb.Rendez();
            Console.WriteLine("Rendezetten: " + tomb);
            Console.WriteLine("Összeg: " + tomb.Osszeg);
        }

        T? Beker<T>(string uzenet, string hibaUzenet, Func<T?, bool> feltetel) where T : IParsable<T>
        {
            T? ertek = default;
            bool helyesErtek = false;
            while (!helyesErtek)
            {
                Console.Write(uzenet);
                T? lehetsegesErtek = Beker<T>(uzenet);
                if (feltetel(lehetsegesErtek))
                {
                    ertek = lehetsegesErtek;
                    helyesErtek = true;
                }
                else
                {
                    Console.WriteLine("Hiba! " + hibaUzenet);
                }
            }
            return ertek;
        }

        T? Beker<T>(string uzenet) where T : IParsable<T>
        {
            T? ertek = default;
            bool helyesErtek = false;
            while (!helyesErtek)
            {
                Console.Write(uzenet);
                if (T.TryParse(Console.ReadLine(), null, out T? result))
                {
                    ertek = result;
                    helyesErtek = true;
                }
                else
                {
                    Console.WriteLine($"Hiba! Csak {typeof(T).Name} típusú értékeket lehet megadni.");
                }
            }
            return ertek;
        }
    }
}
