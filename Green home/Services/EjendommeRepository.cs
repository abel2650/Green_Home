using System;
using System.Collections.Generic;
using Green_home.Services;

namespace Green_home.Model
{
    public class EjendommeRepository : IEjendommeRepository
    {
        public List<Ejendomme> _ejendomme;

        public EjendommeRepository()
        {
            _ejendomme = new List<Ejendomme>();
        }

        public List<Ejendomme> GetAll()
        {
            return new List<Ejendomme>(_ejendomme);
        }

        public void AddEjendomme(Ejendomme ejendomme)
        {
            _ejendomme.Add(ejendomme);
        }

        public Ejendomme Add(Ejendomme e)
        {
            Ejendomme newEjendomme = new Ejendomme(e.Id, e.Pris, e.Kvm, e.Energimærke);
            _ejendomme.Add(newEjendomme);
            return newEjendomme;
        }

        public Ejendomme Delete(int id)
        {
            Ejendomme deleteEjendomme = GetById(id);
            _ejendomme.Remove(deleteEjendomme);
            return deleteEjendomme;
        }

        public Ejendomme Update(int id, Ejendomme ejendomme)
        {
            if (id != ejendomme.Id)
            {
                throw new ArgumentException(
                    $"Kan ikke opdatere en ejendom med id {id} med en ejendom med et andet id {ejendomme.Id}");
            }

            Ejendomme updateEjendomme = GetById(id);

            // Opret en ny ejendom med de opdaterede egenskaber og det samme id
            Ejendomme updatedEjendomme = new Ejendomme(id, ejendomme.Pris, ejendomme.Kvm, ejendomme.Energimærke);

            // Find indekset for den eksisterende ejendom og erstat den med den opdaterede ejendom
            int index = _ejendomme.IndexOf(updateEjendomme);
            _ejendomme[index] = updatedEjendomme;

            return updatedEjendomme;
        }

        public Ejendomme GetById(int id)
        {
            foreach (Ejendomme ejendomme in _ejendomme)
            {
                if (ejendomme.Id == id)
                {
                    return ejendomme;
                }
            }

            throw new ArgumentException($"Der findes ingen ejendom med id {id}");
        }

        public int GenerateNextId()
        {
            if (_ejendomme.Count == 0)
            {
                return 1;
            }

            return _ejendomme[_ejendomme.Count - 1].Id + 1;
        }
    }
}