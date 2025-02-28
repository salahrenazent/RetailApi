﻿using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IPromotionSchemaService
    {
        public List<PromotionSchema> GetAllItemBrand();
        public Int32 Insert(PromotionSchema promotionSchema);
        public Int32 Update(PromotionSchema promotionSchema);
        public PromotionSchema GetSchema(int id);
        public bool DeleteSchema(int id);
    }
}
