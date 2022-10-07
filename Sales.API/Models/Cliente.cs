using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.API.Models
{
    public class Cliente
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public int Age {get;set;}
        public bool Active {get;set;}
        public string Identity {get;set;}

    }
}