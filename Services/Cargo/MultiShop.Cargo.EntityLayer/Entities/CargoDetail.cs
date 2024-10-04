﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.EntityLayer.Entities
{
    public class CargoDetail
    {
        public int CargoDetailID { get; set; }
        public string SenderCustomer  { get; set; }
        public string RecieverCustomer  { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyID { get; set; }


        //Nav Props.
        public CargoCompany CargoCompany { get; set; }
    }
}
