using RetailApi.Dtos;
using RetailApi.Models;

namespace RetailApi.DAL.Interfaces
{
    public interface IAttachmentService
    {
        public Int32 Insert(Attachments attachments);
        public bool Delete(Attachments attachments);
        public List<Attachments> list(AttachmentInput attachments);
    }
}
