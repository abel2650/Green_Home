namespace Green_home.Model;

public class Ejendomme
{
    private int _Id;
    private float _pris;
    private int _kvm;
    private string _energimærke;

    public Ejendomme(int id, float pris, int kvm, string energimærke)
    {
        _Id = id;
        _pris = pris;
        _kvm = kvm;
        _energimærke = energimærke;
    }

    public int Id
    {
        get;
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

    public override string ToString()
    {
        return base.ToString();
    }
}

