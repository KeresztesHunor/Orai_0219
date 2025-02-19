namespace Orai_0219
{
    internal struct Tanulo(string nev, int eletkor, string varos)
    {
        public string nev { get; set; } = nev;
        public int eletkor { get; set; } = eletkor;
        public string varos { get; set; } = varos;
        List<byte> jegyei { get; } = [];

        public void AddJegy(byte jegy)
        {
            jegyei.Add(jegy);
        }

        public override string ToString() => $"{nameof(nev)}: {nev}, {nameof(eletkor)}: {eletkor}, {nameof(varos)}: {varos}, {nameof(jegyei)}: {string.Join(", ", jegyei)}, Átlag: {jegyei.Average((byte jegy) => (float)jegy)}";
    }
}
