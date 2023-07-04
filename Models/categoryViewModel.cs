using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_TASKS.Models
{
    public class categoryViewModel
    {
        public int ID { get; set; }


        public string Arabic_name { get; set; }


        public string English_name { get; set; }

        public DateTime? Start_date { get; set; }

        public DateTime? End_date { get; set; }

        public string state { get; set; }
        public int? creation_user_id { get; set; }

        public DateTime? creation_date { get; set; }

        public int? update_user_ID { get; set; }

        public DateTime? update_Date { get; set; }
    }
}