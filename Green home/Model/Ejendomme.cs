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
}

