using FluentValidation;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Queries.GetDocumentTypeRequisiteDetails
{
    public class GetDocumentTypeRequisiteDetailsQueryValidator:AbstractValidator<GetDocumentTypeRequisiteDetailsQuery>
    {
        public GetDocumentTypeRequisiteDetailsQueryValidator()
        {
            RuleFor(req => req.Id).NotEmpty();
        }
    }
}
