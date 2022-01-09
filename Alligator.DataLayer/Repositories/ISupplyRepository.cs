using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface ISupplyRepository
    {
        int AddSupply(Supply supply);
        void DeleteSupply(int id);
        void EditSupply(Supply supply);
        List<Supply> GetSupplies();
        Supply GetSupplyById(int id);
    }
}