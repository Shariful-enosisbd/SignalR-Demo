using SignalRDemo.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDemo.Repository.Interfaces;

public interface IFakeProductRepository
{
    List<Product> GetAll();
}
