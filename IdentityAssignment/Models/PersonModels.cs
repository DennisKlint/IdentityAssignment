using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityAssignment.Models
{
    public class PersonModels
    {
        public int ID { get; set; }
        public int CityModelsID { get; set; }
        public string Name { get; set; }

        public CityModels Cities { get; set; }
    }
}