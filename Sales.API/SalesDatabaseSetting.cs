using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API
{
    public class SalesDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ItemCollection { get; set; }
        public string CustomerCollection { get; set; }
        public string OrderCollection { get; set; }        
    }
}