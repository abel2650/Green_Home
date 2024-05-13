using Green_home.Model;
using System.Collections.Generic;

namespace Green_home.Services
{
    public interface IEjendommeRepository
    {
        List<Ejendomme> GetAll();
        void AddEjendomme(Ejendomme ejendomme);
        Ejendomme Add(Ejendomme e);
        Ejendomme Delete(int id);
        Ejendomme Update(int id, Ejendomme ejendomme);
        Ejendomme GetById(int id);
        int GenerateNextId();
    }
}