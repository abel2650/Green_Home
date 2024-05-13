using Green_home.Model;

namespace Green_home.Services;

public class EjendommeSortByPris : IComparer<Ejendomme>
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