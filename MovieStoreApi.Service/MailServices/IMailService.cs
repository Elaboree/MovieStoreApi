using System.Threading.Tasks;

namespace MovieStoreApi.Service.MailServices
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequestModel mailRequest);
    }
}
