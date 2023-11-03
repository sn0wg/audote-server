using Audote.Server.Application.Animals.Commands;
using Audote.Server.Application.Animals.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Audote.Server.Web.Controllers
{
    [ApiController]
    [Route("animal")]
    public class AnimalController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnimalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateAnimalCommand animalCommand, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(animalCommand, cancellationToken);
            return result.Match<IResult>(
                sucess => TypedResults.Created($"{result.Value}"),
                err => TypedResults.BadRequest(err));
        }

        [HttpGet]
        public async Task<IResult> Get([FromQuery] GetAnimalsQuery command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return result.Match<IResult>(
                sucess => TypedResults.Ok(sucess), 
                err => TypedResults.BadRequest(err));
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var command = new GetAnimalQuery
            {
                Id = id
            };

            var result = await _mediator.Send(command, cancellationToken);

            if (result != null)
                return TypedResults.Ok(result);

            return TypedResults.NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteById([FromRoute] int id, CancellationToken cancellationToken)
        {
            var command = new DeleteAnimalCommand
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
