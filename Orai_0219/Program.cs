using System.Numerics;

namespace Orai_0219
{
    internal class Program
    {
        static readonly Random rnd = new Random();

        static void Main(string[] args)
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
            Muvelet muvelet = new Muvelet(SzamotBeker<float>("Add meg az x értékét: "), SzamotBeker<float>("Add meg az y értékét: "), ((Func<char>)(() => {
                Console.Write("Add meg a műveletet (+, -, *, /): ");
                string? line = Console.ReadLine();
                return line != null && line.Length == 1 ? line[0] : throw new InvalidOperationException("Csak 1 karakteres operátort lehet megadni!");
            }))());
            muvelet.Kiszamol();
            Console.WriteLine(muvelet);
            Console.ReadLine();
        }

        static T SzamotBeker<T>(string uzenet) where T : struct, INumber<T>
        {
            T ertek = default;
            bool helyesErtek = false;
            while (!helyesErtek)
            {
                Console.Write(uzenet);
                if (T.TryParse(Console.ReadLine(), null, out T result))
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
