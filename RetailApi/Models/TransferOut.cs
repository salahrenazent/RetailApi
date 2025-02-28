namespace RetailApi.Models
{
    public class TransferOut
    {
        public int ID { get; set; }
        public int COMPANY_ID { get; set; }
        public int STORE_ID { get; set; }
        public string TRANSFER_NO { get; set; }
        public DateTime TRANSFER_DATE { get; set; }
        public int DEST_STORE_ID { get; set; }
        public string STORE_NAME { get; set; }
        public float NET_AMOUNT { get; set; }
        public string NARRATION { get; set; }
        public string STATUS { get; set; }
        public int USER_ID { get; set; }
        public List<TransferOutDetails> TransferOutDetail { get; set; }
    }
    public class TransferOutDetails
    {
        public int ID { get; set; }
        public int COMPANY_ID { get; set; }
        public int STORE_ID { get; set; }
        public string STORE_NAME { get; set; }
        public int TRANSFER_ID { get; set; }
        public int ITEM_ID { get; set; }
        public string ITEM_NAME { get; set; }
        public string BAR_CODE { get; set; }
        public float QTY_STOCK { get; set; }
        public string UOM { get; set; }
        public float QUANTITY { get; set; }
        public float COST { get; set; }
        public float AMOUNT { get; set; }
        public string BATCH_NO { get; set; }
        public DateTime? EXPIRY_DATE { get; set; }
    }
    public class InputStore
    {
        public int STORE_ID { get; set; }
    }
    public class ItemDetails
    {
        public int ITEM_ID { get; set; }
        public string UOM { get; set; }
        public int UNIT_ID { get; set; }
        public Decimal COST { get; set; }
        public string ITEM_CODE { get; set; }
        public string ITEM_NAME { get; set; }
        public string BAR_CODE { get; set; }
        public Decimal QTY_STOCK { get; set; }
        public Decimal STORE_SALE_PRICE { get; set; }
        public Decimal ITEM_SALE_PRICE { get; set; }
    }
    public class ItemDetailsResponse
    {
        public int Flag { get; set; }

        public string Message { get; set; }
        public List<ItemDetails> data { get; set; }
    }
    public class TransferOutResponse
    {
        public int Flag { get; set; }

        public string Message { get; set; }
        public List<TransferOut> data { get; set; }
    }
}
