using MediatR;

namespace MovieStoreApi.Service.v1.Query
{
    public class SendRecommendationQuery: IRequest
    {
        public MailRequestModel MailRequest { get; set; }
    }
}
