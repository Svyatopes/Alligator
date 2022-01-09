using Alligator.BusinessLayer.Models;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Service
{
    public interface ISupplyService
    {
        bool DeleteSupply(int id);
        List<SupplyModel> GetAllSupplies();
        SupplyModel GetSupplyById(int id);
        int InsertSupply(SupplyModel supply);
        bool UpdateSupply(SupplyModel supply);
    }
}