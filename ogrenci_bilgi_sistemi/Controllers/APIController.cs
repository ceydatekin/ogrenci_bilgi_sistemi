using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ogrenci_bilgi_sistemi.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ogrenci_bilgi_sistemi.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ogrenci_bilgi_sistemi.Controllers
{
    [ApiController]
    public class APIController : ControllerBase
    {
        ogretmenRepository ogretmenRepository = new ogretmenRepository();
        ogrenciRepository ogrenciRepository = new ogrenciRepository();
        ogretmenDersRepository ogretmenDersRepository = new ogretmenDersRepository();
        dersRepository dersRepository = new dersRepository();
        ogretmenDersRepository ogretmendersRepo = new ogretmenDersRepository();
        ogrenciSistemiRepository ogrenciSistemirepo = new ogrenciSistemiRepository();

        // GET: api/<APIController>
        [HttpPost]
        [Route("api/ogrenci/ekle")]
        public string OgrenciEkle([FromForm] modelOgrenciEkleme model)
        {
            ogrenciRepository.Insert(new Ogrenci()
            {
                Adi = model.ad,
                Soyadi = model.soyad,
                Telno = model.telno
            });
            return JsonConvert.SerializeObject(new { success = true, message = "Tebirkler" });
        }

        [HttpPost]
        [Route("api/ogretmen/ekle")]
        public string OgretmenEkle([FromForm] modelOgretmenEkleme model)
        {

            ogretmenRepository.Insert(new Ogretman()
            {
                Adi = model.ad,
                Soyadi = model.soyad,
                Telno = model.telno
            });
            return JsonConvert.SerializeObject(new { success = true, message = "Tebirkler" });
        }

        [HttpPost]
        [Route("api/dersata/ekle")]
        public string dersata([FromForm] modelOgretmenDersEkleme model)
        {

            ogretmendersRepo.Insert(new OgretmenDer()
            {
                DersId = int.Parse(model.DersId),
                OgretmenId = int.Parse(model.ogretmenId)

            });
            return JsonConvert.SerializeObject(new { success = true, message = "Tebirkler" });
        }

        [HttpGet]
        [Route("api/derslistele")]
        public string derslistele([FromForm] modelderslistele model)
        {
            ogrenciContext context = ogrenciContext.getNesne();
            var list = (from _ogrenci in context.Ogrencis
                        join _ogrencisistemi in context.OgrenciSistemis on _ogrenci.Id equals _ogrencisistemi.OgrenciId
                        join _ogretmen in context.Ogretmen on _ogrencisistemi.Id equals _ogretmen.Id
                        join _ogretmenders in context.OgretmenDers on _ogretmen.Id equals _ogretmenders.OgretmenId
                        join _ders in context.Ders on _ogretmenders.DersId equals _ders.Id
                        select new
                        {
                            OgrenciAdi = _ogrenci.Adi + " " + _ogrenci.Soyadi,
                            OgretmenAdi = _ogretmen.Adi + " " + _ogretmen.Soyadi,
                            Ders = _ders.DersAdi
                        }).ToList();
           // context.Dispose();

            return JsonConvert.SerializeObject(new { success = true, message = "Tebirkler", data = list });
        }

        [HttpPost]
        [Route("api/derskayit")]
        public string derskayit([FromForm] modeldersKaydetme model)
        {



            var bul = ogretmenDersRepository.GetId(int.Parse(model.ogretmenId), int.Parse(model.DersId));



            if (bul.Count > 0)
            {
                for (int i = 0; i < bul.Count; i++)
                {
                    var b = bul[i];
                    //var idbulunan = ogretmenDersRepository.GetIdsonuc(int.Parse(b.DersId + ""), int.Parse(b.OgretmenId + ""));

                    ogrenciSistemirepo.Insert(new OgrenciSistemi()
                    {
                        OgrenciId = int.Parse(model.ogrenciId),
                        OgretmenDersId = b.Id

                    });


                }
            }


            return JsonConvert.SerializeObject(new { success = true, message = "Tebirkler" });
        }


        [Route("API/OgretmeninDersleriniGetir")]
        public string OgretmeninDersleriniGetir(int ogretmenId)
        {
            var lectures = ogretmenDersRepository.GetTeachersLectures(ogretmenId);

            var listLectures = new List<Models.Der>();

            if (lectures.Count > 0)
            {
                for (int i = 0; i < lectures.Count; i++)
                {
                    var lecture = lectures[i];
                    var ders = dersRepository.GetById(int.Parse(lecture.DersId + ""));
                    listLectures.Add(new Der()
                    {
                        DersAdi = ders.DersAdi,
                        Id = ders.Id
                    });


                }
            }

            //listLectures.Add(new Der() {DersAdi = "Matematik", Id = 1 });
            return JsonConvert.SerializeObject(listLectures);
        }


        [HttpGet]
        [Route("api/harflelistele")]
        public string harflelistele(string harf)
        {
            var l = ogrenciRepository.GetOgrenciOgretmenDers(harf);

            var liste = new List<Models.Ogrenci>();
            if (l.Count > 0)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    var og = l[i];
                    var ogrenci = ogrenciRepository.GetById(int.Parse(og.Id + ""));
                    liste.Add(new Ogrenci()
                    {
                        Id = ogrenci.Id,
                        Adi = ogrenci.Adi,
                        Soyadi = ogrenci.Soyadi
                    }); ;

                }

                ogrenciContext context = ogrenciContext.getNesne();
                var deneme = (from _ogrenci in liste
                              join _ogrencisistemi in context.OgrenciSistemis on _ogrenci.Id equals _ogrencisistemi.OgrenciId
                              join _ogretmen in context.Ogretmen on _ogrencisistemi.Id equals _ogretmen.Id
                              join _ogretmenders in context.OgretmenDers on _ogretmen.Id equals _ogretmenders.OgretmenId                             
                              join _ders in context.Ders on _ogretmenders.DersId equals _ders.Id
                              select new
                              {
                                  OgrenciAdi = _ogrenci.Adi + " " + _ogrenci.Soyadi,
                                  OgretmenAdi = _ogretmen.Adi + " " + _ogretmen.Soyadi,
                                  Ders = _ders.DersAdi
                              }).ToList();
                
                return JsonConvert.SerializeObject(new { success = true, message = "Tebirkler", data = deneme });

            }
            else
                return JsonConvert.SerializeObject(new { success = false, message = "Hata", data = "" });
        }


    }

    public class modelOgrenciEkleme
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telno { get; set; }
    }
    public class modelOgretmenEkleme
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string telno { get; set; }
    }
    public class modelOgretmenDersEkleme
    {
        public string ogretmenId { get; set; }
        public string DersId { get; set; }
    }
    public class modeldersKaydetme
    {
        public string ogrenciId { get; set; }
        public string ogretmenId { get; set; }
        public string DersId { get; set; }

    }
    public class modelderslistele
    {
        public string ogrenciId { get; set; }
        public string ogretmenId { get; set; }
        public string DersId { get; set; }
    }
}

