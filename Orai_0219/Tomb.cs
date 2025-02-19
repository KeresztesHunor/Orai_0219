using System.Collections;
using System.Numerics;

namespace Orai_0219
{
    internal struct Tomb<T>(int elemszam) : IReadOnlyList<T> where T : struct, IBinaryInteger<T>
    {
        static readonly Random rnd = new Random();

        public int Osszeg => tomb.Sum(static (T ertek) => int.CreateChecked(ertek));

        public int Count => tomb.Length;

        T[] tomb { get; } = new T[elemszam];

        public T this[int index] => tomb[index];

        public void Feltolt(int? seed = null)
        {
            Random rnd = seed != null ? new Random(seed.Value) : Tomb<T>.rnd;
            for (int i = 0; i < Count; i++)
            {
                tomb[i] = T.CreateChecked(rnd.Next(1, 101));
            }
        }

        public void Rendez()
        {
            tomb.InsertionSort();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in tomb)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => string.Join(", ", tomb);
    }
}
