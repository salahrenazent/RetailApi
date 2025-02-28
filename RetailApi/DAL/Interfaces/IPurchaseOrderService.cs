﻿using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IPurchaseOrderService
    {
        public List<SupplierList> GetSupplier(SupplierInput input);
        public Int32 Insert(PurchaseOrderHeader worksheet);
        public List<PurchaseOrderHeader> GetPOList(Int32 intUserID);
        public Int32 Update(PurchaseOrderHeader worksheet);
        public Int32 Verify(PurchaseOrderHeader worksheet);
        public Int32 Approval(PurchaseOrderHeader worksheet);
        public List<ItemList> GetItemList(ItemInput input);
        public PurchaseOrderHeader GetPurchaseOrder(int id);
    }
}
