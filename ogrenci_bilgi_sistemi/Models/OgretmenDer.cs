using System;
using System.Collections.Generic;

#nullable disable

namespace ogrenci_bilgi_sistemi.Models
{
    public partial class OgretmenDer
    {
        public long Id { get; set; }
        public long? OgretmenId { get; set; }
        public long? DersId { get; set; }
    }
}
