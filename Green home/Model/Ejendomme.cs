namespace Green_home.Model;

public class Ejendomme
{
    // private int _id;
    // private float _pris;
    // private int _kvm;
    // private string _energimærke;
    // private int _by_id;

    public Ejendomme(int id, float pris, int kvm, string energimærke, int by_id)
    {
        Id = id;
        Pris = pris;
        Kvm = kvm; 
        Energimærke = energimærke;
        By_id = by_id;
    }
    
    public Ejendomme() :this(1, 150, 10, "dummy", 1){}
    

    public int Id
    {
        
        get;
        set;
    }
    public float Pris
    {
        get;
        set;
    }
    public int Kvm
    {
        get;
        set;
    }

    public string Energimærke
    {
        get;
        set;
        
    }


    public int By_id
    {
        get;
        set;

    }
    
    




    public override string ToString()
    {
        return base.ToString();
    }
}

