namespace API_TASKS.ShopStoreEF
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Arabic_Name { get; set; }

        [StringLength(50)]
        public string English_Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        public int? Creation_user_id { get; set; }

        public DateTime? Creation_date { get; set; }

        public int? Update_user { get; set; }

        public DateTime? Update_date { get; set; }

        public int? Cate_ID { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
    }
}
