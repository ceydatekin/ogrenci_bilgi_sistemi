using System;
using System.Collections.Generic;

#nullable disable

namespace ogrenci_bilgi_sistemi.Models
{
    public partial class Ogrenci
    {
        public long Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Telno { get; set; }
    }
}
