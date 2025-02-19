namespace Orai_0219
{
    internal class Allat2(string nev = "Ödön", string hang = "KárKár")
    {
        string nev { get; } = nev;
        string hang { get; } = hang;

        public override string ToString() => $"A(z) {nev} azt mondja, hogy {hang}";
    }
}
