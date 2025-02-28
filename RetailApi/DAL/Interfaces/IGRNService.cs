﻿using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IGRNService
    {
        public List<PO> GetPendingPo(poinput input);
        public GRNResponse GetPoList(PODetailsInput input);
        public List<GRN> GetGRNList(Int32 userId);
        public Int32 Insert(GRN company);
        public Int32 Update(GRN company);
        public Int32 Verify(GRN company);
        public Int32 Approve(GRN company);
        public GRN GetGRN(int id);
        public bool Delete(int id);
    }
}
