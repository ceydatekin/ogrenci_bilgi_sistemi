using Microsoft.EntityFrameworkCore;
using ogrenci_bilgi_sistemi.Models;
using ogrenci_bilgi_sistemi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ogrenci_bilgi_sistemi.Manager
{
    public class ogretmenRepository : IRepository<Ogretman>
    {
        //veri tabanı bağlantısını kurduğumuz nesneyi oluşturduk.
        ogrenciContext context = ogrenciContext.getNesne();
        public void Delete(Ogretman entity)
        {
            this.context.Ogretmen.Remove(entity);
        }

        public IEnumerable<Ogretman> Find(Expression<Func<Ogretman, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ogretman> GetAll()
        {
            return context.Ogretmen.ToList();
        }

        public Ogretman GetById(int id)
        {
            return context.Ogretmen.Find(id);
        }

        public void Insert(Ogretman entity)
        {
            this.context.Ogretmen.Add(entity);
            Save();
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        
        public void Update(Ogretman entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
