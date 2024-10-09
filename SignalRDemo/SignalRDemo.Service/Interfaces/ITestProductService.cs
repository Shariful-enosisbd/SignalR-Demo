using SignalRDemo.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDemo.Service.Interfaces;

public interface ITestProductService
{
    Product GetProductById(int id);
}
