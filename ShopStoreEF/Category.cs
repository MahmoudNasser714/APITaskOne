namespace API_TASKS.ShopStoreEF
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Arabic_name { get; set; }

        [StringLength(50)]
        public string English_name { get; set; }

        public DateTime? Start_date { get; set; }

        public DateTime? End_date { get; set; }

        public bool? state { get; set; }

        public int? creation_user_id { get; set; }

        public DateTime? creation_date { get; set; }

        public int? update_user_ID { get; set; }

        public DateTime? update_Date { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
