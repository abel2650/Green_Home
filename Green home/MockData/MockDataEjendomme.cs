using Green_home.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Green_home.MockData
{
    public class EjendommeMockData
    {
        private static readonly IList<Ejendomme> _ejendomme = new Collection<Ejendomme>()
        {
            new Ejendomme(1, 1000000, 120, "A"),
            new Ejendomme(2, 750000, 100, "B"),
            new Ejendomme(3, 1500000, 200, "C"),
            new Ejendomme(4, 500000, 80, "D"),
            new Ejendomme(5, 2000000, 250, "E"),
            new Ejendomme(6, 900000, 110, "F"),
            new Ejendomme(7, 3000000, 180, "G"),
            new Ejendomme(8, 600000, 90, "H"),
            new Ejendomme(9, 1800000, 150, "I"),
            new Ejendomme(10, 1200000, 130, "J"),
            new Ejendomme(11, 2400000, 220, "K"),
            new Ejendomme(12, 850000, 105, "L"),
            new Ejendomme(13, 3500000, 200, "M")
        };

        public static ICollection<Ejendomme> GetEjendomme { get { return new Collection<Ejendomme>(_ejendomme); } }
    }
}