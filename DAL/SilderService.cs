﻿using BE;
using BLL;

namespace DAL
{
    public class SilderService : ISilderService
    {
        private readonly DB _db;

        public SilderService(DB db)
        {
            _db = db;
        }

        public void AddSilder(Silder model)
        {
            _db.silders.Add(model);
            _db.SaveChanges();
        }

        public List<Silder> GetAllSilders()
        {
            return _db.silders.ToList();
        }
        public Silder GetSilderById(int Id)
        {
            return _db.silders.FirstOrDefault(u => u.SliderId == Id);
        }

        public void EditSilder(Silder silder)
        {
            _db.silders.Update(silder);
            _db.SaveChanges();
        }
    }
}
