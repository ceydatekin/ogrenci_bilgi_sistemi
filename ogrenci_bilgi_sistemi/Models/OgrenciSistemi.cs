using System;
using System.Collections.Generic;

#nullable disable

namespace ogrenci_bilgi_sistemi.Models
{
    public partial class OgrenciSistemi
    {
        public long Id { get; set; }
        public long? OgrenciId { get; set; }
        public long? OgretmenDersId { get; set; }
    }
}
