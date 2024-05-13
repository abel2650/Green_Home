using Green_home.Model;

namespace Green_home.Services;

public class EjendommeSortByKvm: IComparer<Ejendomme>
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