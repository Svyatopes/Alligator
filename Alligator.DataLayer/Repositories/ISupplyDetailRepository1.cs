using Alligator.DataLayer.Entities;
using System.Collections.Generic;

namespace Alligator.DataLayer.Repositories
{
    public interface ISupplyDetailRepository1
    {
        int AddSupplyDetail(SupplyDetail supplyDetail);
        void DeleteSupplyDetailById(int id);
        void DeleteSupplyDetailBySupplyId(int id);
        void EditSupplyDetail(List<SupplyDetail> supplyDetail);
        List<SupplyDetail> GetAllSupplyDetails();
        List<SupplyDetail> GetSupplyDetailBySupplyId(int id);
    }
}