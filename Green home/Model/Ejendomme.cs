namespace Green_home.Model;

public class Ejendomme
{
    // private int _id;
    // private float _pris;
    // private int _kvm;
    // private string _energimærke;
    // private int _by_id;

    public Ejendomme(int id, double pris, int kvm, string energimærke, int post_nr)
    {
        Id = id;
        Pris = pris;
        Kvm = kvm; 
        Energimærke = energimærke;
        Post_nr = post_nr;
    }
    
    public Ejendomme() :this(1, 150, 10, "dummy", 1){}
    

    public int Id   {get;  set;}
    public double Pris   {get;   set;}
    public int Kvm  {get;   set;}
    public string Energimærke   {get;   set;}
    public int Post_nr    {get;   set;}

    public override string ToString()
    {
        return base.ToString();
    }
}

