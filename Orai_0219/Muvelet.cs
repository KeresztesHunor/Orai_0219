namespace Orai_0219
{
    internal class Muvelet(float x, float y, char muvelet)
    {
        float x { get; } = x;
        float y { get; } = y;
        float? eredmeny { get; set; } = null;
        public float Eredmeny => eredmeny ??= muvelet(x, y);

        Func<float, float, float> muvelet { get; } = muvelet switch {
            '+' => (float x, float y) => x + y,
            '-' => (float x, float y) => x - y,
            '*' => (float x, float y) => x * y,
            '/' => (float x, float y) => x / y,
            _ => throw new ArgumentException($"A \"{muvelet}\" karakter nem egy valid operátor!")
        };

        public void Kiszamol()
        {
            eredmeny = muvelet(x, y);
        }

        public override string ToString() => $"Eredmény: {Eredmeny}";
    }
}
