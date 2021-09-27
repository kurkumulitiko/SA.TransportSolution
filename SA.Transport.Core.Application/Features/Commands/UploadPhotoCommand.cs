using MediatR;
using Microsoft.AspNetCore.Http;
using SA.Transport.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace SA.Transport.Core.Application.Features.Commands
{
    public class UploadPhotoRequest : IRequest
    {
        public Guid TransportId { get; set; }
        public IFormFile File { get; set; }

    }

    public class UploadPhotoHandler : IRequestHandler<UploadPhotoRequest>
    {
        private readonly IFileManager fileManager;
        private readonly IUnitOfWork unit;

        public UploadPhotoHandler(IFileManager fileManager, IUnitOfWork unit)
        {
            this.fileManager = fileManager;
            this.unit = unit;
        }

        public Task<Unit> Handle(UploadPhotoRequest request, CancellationToken cancellationToken)
        {
            var fileIdentifier = Guid.NewGuid();
            var fileName = $"{fileIdentifier}{Path.GetExtension(request.File.FileName)}";

            var transport = unit.TransportRepository.GetById(request.TransportId);
            transport.PhotoName = fileName;
            unit.TransportRepository.Update(transport);

            fileManager.SaveFile(request.File, fileName);
            return Task.FromResult(Unit.Value);
        }
    }
}
