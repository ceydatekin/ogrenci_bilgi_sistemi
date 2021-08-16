using ogrenci_bilgi_sistemi.Repository;
using ogrenci_bilgi_sistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace ogrenci_bilgi_sistemi.Manager
{
    public class ogrenciRepository : IRepository<Ogrenci>
    {
        //veri tabanı bağlantısını kurduğumuz nesneyi oluşturduk.
        ogrenciContext context = ogrenciContext.getNesne();

        public void Delete(Ogrenci entity)
        {
            this.context.Ogrencis.Remove(entity);
            Save();
        }

        public IEnumerable<Ogrenci> Find(Expression<Func<Ogrenci, bool>> predicate)
        {

              this.context.Ogrencis.Where(ceyda => ceyda.Adi == "Test" && ceyda.Telno == "-").ToList();
            return this.context.Ogrencis.Where(predicate).ToList();
        }

        public IEnumerable<Ogrenci> GetAll()
        {
            return context.Ogrencis.ToList();
            
        }

        public Ogrenci GetById(int id)
        {
            return context.Ogrencis.SingleOrDefault( s => s.Id == id);
        }

        public void Insert(Ogrenci entity)
        {
            this.context.Ogrencis.Add(entity);
            Save();
            
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Update(Ogrenci entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public List<Ogrenci> GetOgrenciOgretmenDers(string harf)
        {
     
            return context.Ogrencis.Where(entity => entity.Adi.Contains(harf)).ToList();
          
        }
    }
}
