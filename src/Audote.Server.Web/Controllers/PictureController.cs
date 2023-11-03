using Audote.Server.Application.Pictures.Commands;
using Audote.Server.Application.Pictures.Queries;
using Audote.Server.Web.Dto.Pictures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Audote.Server.Web.Controllers
{
    [ApiController]
    [Route("picture")]
    public class PictureController
    {
        private readonly IMediator _mediator;
        public PictureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IResult> Create([FromForm] UploadPictureDto uploadPictureDto, CancellationToken cancellationToken)
        {
            var command = new UploadPictureCommand
            {
                PictureStream = uploadPictureDto.Image.OpenReadStream(),
                ContentType = uploadPictureDto.Image.ContentType,
                Description = uploadPictureDto.Description,
                AnimalId = uploadPictureDto.AnimalId
            };

            var result = await _mediator.Send(command, cancellationToken);

            return result.Match<IResult>(
                sucess => TypedResults.Created($"{result.Value}"),
                err => TypedResults.BadRequest(err));
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var command = new GetPictureQuery
            {
                Id = id
            };

            var result = await _mediator.Send(command, cancellationToken);

            if (result != null)
                return Results.File(result.Data, result.ContentType);

            return TypedResults.NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var command = new DeletePictureCommand
            {
                Id = id
            };

            var ok = await _mediator.Send(command, cancellationToken);

            if (ok)
                return TypedResults.NoContent();

            return TypedResults.NotFound();
        }
    }
}
