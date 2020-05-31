using System;
using System.Collections.Generic;
using System.Text;
using WorkJwt.Business.Interfaces;
using WorksJwt.Dal.Interfaces;
using WorksJwt.Entities.Concrete;

namespace WorkJwt.Business.Concrete
{
    public class ProductManager : GenericManager<Product>,IProductService
    {
        public ProductManager(IGenericDal<Product> genericDal) : base(genericDal)
        {

        }
    }
}
