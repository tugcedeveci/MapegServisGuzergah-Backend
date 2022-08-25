using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapegServisGuzergah.Models.View_Models
{
    public class DTParameters
    {
        public int Draw { get; set; }

        // Tablonun kolon adlarını içeren dizi
        public DTColumn[] Columns { get; set; }

        /// Kaç tane kolon  sıralanacak, bir eleman varsa tek bir  alana göre sıralanacak.Birden fazlaysa multi-column sort uygulanacak
        public DTOrder[] Order { get; set; }

        // Skip() ' te  kullanılacak veri (current dataset in başlangıç noktası )
        public int Start { get; set; }

        //o filtreden sonra gösterilecek satır sayısı 
        public int Length { get; set; }

        //Bütün alanlara uygulanan search verisi
        public DTSearch Search { get; set; }

        // İlk sıralama kolonunun  daha ileri sıralanması için kulanılır
        public string SortOrder
        {
            get
            {
                return Columns != null && Order != null && Order.Length > 0
                    ? (Columns[Order[0].Column].Data + (Order[0].Dir == DTOrderDir.DESC ? " " + Order[0].Dir : string.Empty))
                    : null;
            }
        }
    }

    public class DTSearch
    {
        // Bütün alanlara uygulanan  search verisi
        public string Value { get; set; }

        //Arama için kullanılacak Regex verisi. Çok büük verisetlerini filtrlemekte kullanılabilir.
        public bool Regex { get; set; }
    }

    public class DTColumn
    {
        //columns.data  ile tanımlanan kolon verisi 
        public string Data { get; set; }

        // columns.name ile tanımlanan column adi
        public string Name { get; set; }

        //Column searchable mı değil mi anlamında 
        public bool Searchable { get; set; }

        /// Kolon sıralama enabled mı ?  columns.orderable ile ayarlanır
        public bool Orderable { get; set; }

    }
    public class DTOrder
    {
        // Sıralamada baz alınacak kolon
        public int Column { get; set; }

        // OSıralama Yönü , asc  -   desc
        public DTOrderDir Dir { get; set; }
    }
    public enum DTOrderDir
    {
        ASC,
        DESC
    }
}
