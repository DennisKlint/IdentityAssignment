using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityAssignment.Models
{
    public class CountryModels
    {
        public int ID { get; set; }
        public string CountryName { get; set; }

        public ICollection<CityModels> Cities { get; set; }
    }
}