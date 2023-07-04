using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_TASKS.Models
{
    public class productViewModel
    {
        public int ID { get; set; }

        public string Arabic_Name { get; set; }

        public string English_Name { get; set; }

        public decimal? Price { get; set; }

        public string Description { get; set; }

        public string Manufacturer { get; set; }

        public string State { get; set; }

        public int? Creation_user_id { get; set; }

        public DateTime? Creation_date { get; set; }

        public int Update_user { get; set; }

        public DateTime? Update_date { get; set; }

        public int? Cate_ID { get; set; }
    }
}