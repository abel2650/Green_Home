using Green_home.Model;

namespace Green_home.Services
{
    public interface IEjendommeRepositoryDB
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