﻿namespace Audote.Server.WebApi.Dto.Pictures
{
    public class UploadPictureDto
    {
        public IFormFile Image { get; set; }
        public string Description { get; set; }
        public int AnimalId { get; set; }
    }
}
