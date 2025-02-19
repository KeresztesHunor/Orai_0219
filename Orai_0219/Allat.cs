namespace Orai_0219
{
    internal class Allat(string nev = "Névtelen", string hang = "Hangtalan")
    {
        public string nev { get; set; } = nev;
        public string hang { get; set; } = hang;

        public override string ToString() => $"A(z) {nev} azt mondja, hogy {hang}";
    }
}
