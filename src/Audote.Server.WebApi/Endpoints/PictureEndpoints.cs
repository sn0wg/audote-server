using Audote.Server.Application.Animals.Commands;
using Audote.Server.Application.Pictures.Commands;
using Audote.Server.Application.Pictures.Queries;
using Audote.Server.WebApi.Dto.Pictures;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Audote.Server.WebApi.Endpoints
{
    public class PictureEndpoints
    {
        public static void Map(WebApplication webApplication)
        {
            var group = webApplication.MapGroup("/picture");

            group
                .MapPost("", HandlePost)
                .WithName("UploadPicture")
                .WithOpenApi();

            group
                .MapDelete("{id:int}", HandleDelete)
                .WithName("DeletePicture")
                .WithOpenApi();

            group
                .MapGet("{id:int}", HandleGet)
                .WithName("GetPicture")
                .WithOpenApi();
        }

        private static async Task<Created> HandlePost(UploadPictureDto uploadPictureDto, IMediator mediator, CancellationToken cancellationToken)
        {
            var command = new UploadPictureCommand
            {
                PictureStream = uploadPictureDto.Image.OpenReadStream(),
                ContentType = uploadPictureDto.Image.ContentType,
                Description = uploadPictureDto.Description,
                AnimalId = uploadPictureDto.AnimalId
            };

            var result = await mediator.Send(command, cancellationToken);

            return TypedResults.Created($"{result}");
        }

        private static async Task<IResult> HandleDelete([FromRoute] int id, IMediator mediator, CancellationToken cancellationToken)
        {
            var command = new DeletePictureCommand
            {
                Id = id,
            };

            var ok = await mediator.Send(command, cancellationToken);

            if (ok)
                return TypedResults.NoContent();

            return TypedResults.NotFound();
        }

        private static async Task<IResult> HandleGet([FromRoute] int id, IMediator mediator, CancellationToken cancellationToken)
        {
            var command = new GetPictureQuery
            {
                Id = id,
            };

            var image = await mediator.Send(command, cancellationToken);

            if (image != null)
                return Results.File(image.Data, image.ContentType);

            return TypedResults.NotFound();
        }
    }
}
