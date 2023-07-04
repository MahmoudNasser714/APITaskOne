namespace API_TASKS.ShopStoreEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [StringLength(50)]
        public string arabic_name { get; set; }

        [StringLength(50)]
        public string English_name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(11)]
        public string Mobile { get; set; }

        public int ID { get; set; }
    }
}
