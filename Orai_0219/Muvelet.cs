namespace Orai_0219
{
    internal struct Muvelet(float x, float y)
    {
        float x { get; } = x;
        float y { get; } = y;
        float? eredmeny { get; set; } = null;

        public float Eredmeny => eredmeny ?? throw new InvalidOperationException("A művelet nem lett még végrehajtva!");

        public void Kiszamol(char muvelet)
        {
            eredmeny = muvelet switch {
                '+' => x + y,
                '-' => x - y,
                '*' => x * y,
                '/' => x / y,
                _ => throw new ArgumentException($"A(z) \"{muvelet}\" karakter nem egy valid operátor!")
            };
        }

        public void EredmenytKiir()
        {
            Console.WriteLine("Eredmény: " + Eredmeny);
        }
    }
}
