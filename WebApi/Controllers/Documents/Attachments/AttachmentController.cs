using Application.Documents.Attachments.Attachments.Commands.CreateAttachment;
using Application.Documents.Attachments.Attachments.Commands.DeleteAttachment;
using Application.Documents.Attachments.Attachments.Commands.UpdateAttachment;
using Application.Documents.Attachments.Attachments.Queries.GetAttachmentDetails;
using Application.Documents.Attachments.Attachments.Queries.GetAttachmentList;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Models.Attachments;

namespace WebApi.Controllers.Documents.Attachments
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : BaseController
    {
        private readonly IMapper _mapper;

        public AttachmentController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<AttachmentListVm>> GetAll([FromQuery] bool isDeleted)
        {
            var query = new GetAttachmentListQuery() { IsDeleted = isDeleted };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttachmentDetailsVm>> GetAttachment([FromQuery] Guid id)
        {
            var query = new GetAttachmentDetailsQuery() { Id = id };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAttachmentDto createAttachmentDto)
        {
            var command = _mapper.Map<CreateAttachmentCommand>(createAttachmentDto);
            var attachmentId = await Mediator.Send(command);
            return Ok(attachmentId);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAttachmentDto updateAttachmentDto)
        {
            var command = _mapper.Map<UpdateAttachmentCommand>(updateAttachmentDto);
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var command = new DeleteAttachmentCommand() { Id = id };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
