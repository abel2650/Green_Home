namespace Green_home.Model;

public class Ejendomme
{
    private int _id;
    private float _pris;
    private int _kvm;
    private string _energimærke;
    private int _by_id;

    public Ejendomme(int id, float pris, int kvm, string energimærke, int by_id)
    {
        _id = id;
        _pris = pris;
        _kvm = kvm; 
        Energimærke = energimærke;
        _by_id = by_id;
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
        get { return _energimærke; }
        set
        {
            
        _energimærke = value; }
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

