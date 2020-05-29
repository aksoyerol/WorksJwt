using System;
using System.Collections.Generic;
using System.Text;
using WorksJwt.Entities.Interfaces;

namespace WorksJwt.Entities.Concrete
{
    public class Product : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
