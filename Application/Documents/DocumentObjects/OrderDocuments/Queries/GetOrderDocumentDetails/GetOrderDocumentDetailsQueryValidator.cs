using FluentValidation;

namespace Application.Documents.DocumentObjects.OrderDocuments.Queries.GetOrderDocumentDetails
{
    public class GetOrderDocumentDetailsQueryValidator:AbstractValidator<GetOrderDocumentDetailsQuery>
    {
        public GetOrderDocumentDetailsQueryValidator()
        {
            RuleFor(od => od.Id).NotEmpty();
        }
    }
}
