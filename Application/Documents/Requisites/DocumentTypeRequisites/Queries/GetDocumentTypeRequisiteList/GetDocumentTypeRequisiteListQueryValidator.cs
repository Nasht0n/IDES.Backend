using FluentValidation;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Queries.GetDocumentTypeRequisiteList
{
    public class GetDocumentTypeRequisiteListQueryValidator:AbstractValidator<GetDocumentTypeRequisiteListQuery>
    {
        public GetDocumentTypeRequisiteListQueryValidator()
        {
            RuleFor(req => req.IsDeleted).NotEmpty();
        }
    }
}
