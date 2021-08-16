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
    public class ogrenciSistemiRepository : IRepository<OgrenciSistemi>
    {
        //veri tabanı bağlantısını kurduğumuz nesneyi oluşturduk.
        ogrenciContext context = ogrenciContext.getNesne();
        public void Delete(OgrenciSistemi entity)
        {
            this.context.OgrenciSistemis.Remove(entity);
        }

        public IEnumerable<OgrenciSistemi> Find(Expression<Func<OgrenciSistemi, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OgrenciSistemi> GetAll()
        {
            return context.OgrenciSistemis.ToList();
        }

        public OgrenciSistemi GetById(int id)
        {
            return context.OgrenciSistemis.Find(id);
        }

        public void Insert(OgrenciSistemi entity)
        {
            this.context.OgrenciSistemis.Add(entity);
            Save();
          
        }

        public void Save()
        {
            try
            {

            this.context.SaveChanges();
            }
            catch (Exception err)
            {

            }
        }


        public void Update(OgrenciSistemi entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
