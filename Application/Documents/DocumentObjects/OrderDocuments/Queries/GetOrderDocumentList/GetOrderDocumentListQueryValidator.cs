using System.Data;
using FluentValidation;

namespace Application.Documents.DocumentObjects.OrderDocuments.Queries.GetOrderDocumentList
{
    public class GetOrderDocumentListQueryValidator:AbstractValidator<GetOrderDocumentListQuery>
    {
        public GetOrderDocumentListQueryValidator()
        {
            RuleFor(doc => doc.IsDeleted).NotEmpty();
        }
    }
}
