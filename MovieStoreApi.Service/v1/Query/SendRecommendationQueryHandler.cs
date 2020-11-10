using MediatR;
using MovieStoreApi.Service.MailServices;
using System.Threading;
using System.Threading.Tasks;

namespace MovieStoreApi.Service.v1.Query
{
    public class SendRecommendationQueryHandler : IRequestHandler<SendRecommendationQuery>
    {
        private readonly IMailService _mailService;
        public SendRecommendationQueryHandler(IMailService mailService)
        {
            _mailService = mailService;
        }
        public async Task<Unit> Handle(SendRecommendationQuery request, CancellationToken cancellationToken)
        {
            await _mailService.SendEmailAsync(request.MailRequest);
            return Unit.Value;
        }
    }
}
