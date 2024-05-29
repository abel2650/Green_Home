namespace Green_home.Model
{
    // Denne klasse repræsenterer egenskaberne for ejendomme.
    public class Ejendomme
    {
        // Private felter der repræsenterer attributterne for en ejendom.
        //private int _id;
        //private float _pris;
        //private int _kvm;
        //private string _energimærke;
        //private int _post_nr;

        // Konstruktør til at initialisere et ejendomsobjekt med givne værdier.
        public Ejendomme(int id, double pris, int kvm, string energimærke, int post_nr)
        {
            Id = id;            // Unik identifikator for ejendommen.
            Pris = pris;        // Pris for ejendommen.
            Kvm = kvm;          // Størrelse af ejendommen i kvadratmeter.
            Energimærke = energimærke;  // Energimærke for ejendommen.
            Post_nr = post_nr;  // Postnummer for ejendommens beliggenhed.
        }
        
        // Standard konstruktør der sætter standardværdier for en ejendom.
        public Ejendomme() :this(1, 150, 10, "dummy", 1){}

        // Offentlige egenskaber der repræsenterer attributterne for en ejendom med getters og setters.
        public int Id { get;   set; }             // Unik identifikator for ejendommen.
        public double Pris   {get;   set;}         // Pris for ejendommen.
        public int Kvm  {get;   set;}             // Størrelse af ejendommen i kvadratmeter.
        public string Energimærke   {get;   set;} // Energimærke for ejendommen.
        public int Post_nr  {get;   set;}
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}