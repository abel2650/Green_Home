using System.Collections.Generic;
using Green_home.Model; 

namespace Green_home.Services
{
    public interface IEjendommeRepository_DB
    {
        List<Ejendomme> GetAll();
        void AddEjendomme(Ejendomme ejendomme);
        void DeleteEjendomme(int id);
        void UpdateEjendomme(int id, Ejendomme ejendomme); 
        List<Ejendomme> GetByEnergimaerke(string energimaerke);
    }
}