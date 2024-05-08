using System.Collections.Generic;
using Green_home.Model;

namespace Green_home.Services
{
    public interface IEjendommeRepository
    {
        List<Ejendomme> GetAll();
        void AddEjendomme(Ejendomme ejendomme);
        Ejendomme Add(Ejendomme e);
        Ejendomme Delete(int id);
        Ejendomme Update(int id, Ejendomme ejendomme);
    }
}
