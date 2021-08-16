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
    public class dersRepository : IRepository<Der>
    {
        //veri tabanı bağlantısını kurduğumuz nesneyi oluşturduk.
        ogrenciContext context = ogrenciContext.getNesne();
        
        public void Delete(Der entity)
        {
            this.context.Ders.Remove(entity);
        }

        public IEnumerable<Der> Find(System.Linq.Expressions.Expression<Func<Der, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Der> GetAll()
        {
            return context.Ders.ToList();
        }

        public Der GetById(int id)
        {
            return context.Ders.SingleOrDefault(s => s.Id == id);

        }

        public void Insert(Der entity)
        {
            this.context.Ders.Add(entity);
            
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Update(Der entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

       
    }
}
