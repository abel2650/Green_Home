using Green_home.Model;

namespace Green_home.Services
{
    public class EjendommeSort
    {
        public class SortByKvm : IComparer<Ejendomme>
        {
            public int Compare(Ejendomme x, Ejendomme y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }

                return x.Kvm.CompareTo(y.Kvm);
            }
        }

        public class SortByPris : IComparer<Ejendomme>
        {
            public int Compare(Ejendomme x, Ejendomme y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }

                return x.Pris.CompareTo(y.Pris);
            }
        }

        public class SortById : IComparer<Ejendomme>
        {
            public int Compare(Ejendomme x, Ejendomme y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }

                return x.Id.CompareTo(y.Id);
            }
        }

        public class SortByEnergimaerke : IComparer<Ejendomme>
        {
            public int Compare(Ejendomme x, Ejendomme y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }

                return x.Energimærke.CompareTo(y.Energimærke);
            }
        }
    }
}