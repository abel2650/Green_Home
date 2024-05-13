using System.Linq;
using Green_home.Services;

namespace Green_home.Model
{
    public class EjendommeRepositoryDB : IEjendommeRepositoryDB
    {
        private readonly DB _context;

        public EjendommeRepositoryDB()
        {
            _context = new DbContext();
        }

        public List<Ejendomme> GetAll()
        {
            return _context.Ejendomme.ToList();
        }

        public void AddEjendomme(Ejendomme ejendomme)
        {
            _context.Ejendomme.Add(ejendomme);
            _context.SaveChanges();
        }

        public Ejendomme Add(Ejendomme e)
        {
            _context.Ejendomme.Add(e);
            _context.SaveChanges();
            return e;
        }

        public Ejendomme Delete(int id)
        {
            Ejendomme ejendommeToDelete = _context.Ejendomme.Find(id);
            if (ejendommeToDelete != null)
            {
                _context.Ejendomme.Remove(ejendommeToDelete);
                _context.SaveChanges();
            }
            return ejendommeToDelete;
        }

        public Ejendomme Update(int id, Ejendomme ejendomme)
        {
            Ejendomme existingEjendomme = _context.Ejendomme.Find(id);
            if (existingEjendomme != null)
            {
                existingEjendomme.Pris = ejendomme.Pris;
                existingEjendomme.Kvm = ejendomme.Kvm;
                existingEjendomme.Energimærke = ejendomme.Energimærke;
                _context.SaveChanges();
            }
            return existingEjendomme;
        }

        public Ejendomme GetById(int id)
        {
            return _context.Ejendomme.Find(id);
        }

        public int GenerateNextId()
        {
            if (_context.Ejendomme.Count() == 0)
            {
                return 1;
            }
            return _context.Ejendomme.Max(e => e.Id) + 1;
        }
    }
}