using Audote.Server.Application.Animals.Commands;
using Audote.Server.Application.Animals.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Audote.Server.WebApi.Endpoints
{
    public class AnimalEndpoints
    {
        public static void Map(WebApplication webApplication)
        {
            var group = webApplication.MapGroup("/animal");

            group
                .MapPost("", HandlePost)
                .WithName("CreateAnimal")
                .WithOpenApi();

            group
                .MapGet("", HandleGet)
                .WithName("GetAnimals")
                .WithOpenApi();

            group
                .MapDelete("{id:int}", HandleDelete)
                .WithName("DeleteAnimal")
                .WithOpenApi();

            group
                .MapGet("{id:int}", HandleGetById)
                .WithName("GetAnimalById")
                .WithOpenApi();
        }

        private static async Task<Created> HandlePost([FromBody] CreateAnimalCommand animalCommand, IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(animalCommand, cancellationToken);
            return TypedResults.Created($"{result}");
        }

        private static async Task<IResult> HandleDelete([FromRoute] int id, IMediator mediator, CancellationToken cancellationToken)
        {
            var command = new DeleteAnimalCommand
            {
                Id = id
            };

            var ok = await mediator.Send(command, cancellationToken);

            if (ok)
                return TypedResults.NoContent();

            return TypedResults.NotFound();
        }

        private static async Task<IResult> HandleGetById([FromRoute] int id, IMediator mediator, CancellationToken cancellationToken)
        {
            var command = new GetAnimalQuery
            {
                Id = id
            };

            var result = await mediator.Send(command, cancellationToken);

            if (result != null)
                return TypedResults.Ok(result);

            return TypedResults.NotFound();
        }

        private static async Task<IResult> HandleGet([AsParameters] GetAnimalsQuery command, IMediator mediator, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);

            return TypedResults.Ok(result);
        }
    }
}
