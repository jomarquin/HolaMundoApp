using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundoApp.Data.Models
{
    public class Office
    {
        public long Id { get; set; }
        public string NameOffice { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string OfficeHours { get; set; }
        public string Department { get; set; }
        public string City { get; set; }
        public string OfficeType { get; set; }
        public string UrlImage { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
