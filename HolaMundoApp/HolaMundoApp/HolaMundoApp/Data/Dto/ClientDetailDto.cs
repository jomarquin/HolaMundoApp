using HolaMundoApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundoApp.Data.Dto
{
    public class ClientDetailDto : Client
    {
        public int Age { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public double LifeExpectancy { get; set; }
    }

}
