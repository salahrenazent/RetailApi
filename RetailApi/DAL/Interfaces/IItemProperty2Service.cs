﻿using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IItemProperty2Service
    {
        public List<ItemProperty2> GetAllItemProperty2();
        public Int32 SaveData(ItemProperty2 company);
        public ItemProperty2 GetItems(int id);
        public bool DeleteItemProperty2(int id);
    }
}
