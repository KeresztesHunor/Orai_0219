namespace Orai_0219
{
    internal static class ExtensionMethods
    {
        public static void InsertionSort<T>(this IList<T> values) where T : IComparable<T>
        {
            values.InsertionSort(static (T value) => value);
        }

        public static void InsertionSort<T, U>(this IList<T> values, Func<T, U> selector) where U : IComparable<U>
        {
            for (int i = 1; i < values.Count; i++)
            {
                int previousIndex = i - 1;
                if (values.Compare(previousIndex, i, selector))
                {
                    values.Swap(i, previousIndex);
                    int ii = i - 1;
                    while (ii > 0 && values.Compare(ii - 1, ii, selector))
                    {
                        values.Swap(ii, --ii);
                    }
                }
            }
        }

        static void Swap<T>(this IList<T> values, int index1, int index2)
        {
            (values[index1], values[index2]) = (values[index2], values[index1]);
        }

        static bool Compare<T, U>(this IList<T> values, int index1, int index2, Func<T, U> selector) where U : IComparable<U> => selector(values[index1]).CompareTo(selector(values[index2])) > 0;
    }
}
