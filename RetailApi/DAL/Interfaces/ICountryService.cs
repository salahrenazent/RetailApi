﻿using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface ICountryService
    {
        public List<Country> GetAllCountry();
        public Int32 SaveData(Country company);
        public Country GetItems(int id);
        public bool DeleteCountry(int id);

    }
}
