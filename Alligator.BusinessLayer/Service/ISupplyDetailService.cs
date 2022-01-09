using Alligator.BusinessLayer.Models;
using System.Collections.Generic;

namespace Alligator.BusinessLayer.Service
{
    public interface ISupplyDetailService
    {
        bool DeleteSupplyDetailById(int id);
        bool DeleteSupplyDetailBySupplyId(int id);
        List<SupplyDetailModel> GetAllSupplyDetails();
        List<ProductModel> GetProducts();
        ProductModel GetProductById(int id);
        List<SupplyDetailModel> GetSupplyDetailBySupplyId(int id);
        int InsertSupplyDetail(SupplyDetailModel supplyDetail);
        bool UpdateSupplyDetail(List<SupplyDetailModel> supplyDetail);
    }
}