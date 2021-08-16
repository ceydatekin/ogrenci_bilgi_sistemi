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
    public class ogretmenDersRepository : IRepository<OgretmenDer>
    {
        //veri tabanı bağlantısını kurduğumuz nesneyi oluşturduk.
        ogrenciContext context = ogrenciContext.getNesne();

        public void Delete(OgretmenDer entity)
        {
            this.context.OgretmenDers.Remove(entity);
        }

        public IEnumerable<OgretmenDer> Find(Expression<Func<OgretmenDer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OgretmenDer> GetAll()
        {
            return context.OgretmenDers.ToList();
        }

        public OgretmenDer GetById(int id)
        {
            return context.OgretmenDers.Find(id);
        }

        public void Insert(OgretmenDer entity)
        {
            this.context.OgretmenDers.Add(entity);
            Save();
            
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        public void Update(OgretmenDer entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public List<OgretmenDer> GetTeachersLectures(int teacherId)
        {
            return this.context.OgretmenDers.Where(entity => entity.OgretmenId == teacherId).ToList();
        }
        public List<OgretmenDer> GetId(int teacherId,int lecturesId)
        {
            return this.context.OgretmenDers.Where(entity => entity.OgretmenId == teacherId && entity.DersId==lecturesId).ToList();
        }

        //public OgretmenDer GetIdsonuc(int ogrid , int dersid)
        //{
        //    return context.OgretmenDers.SingleOrDefault(s => s.OgretmenId == ogrid && s.DersId== dersid);
        //}
    }
}
