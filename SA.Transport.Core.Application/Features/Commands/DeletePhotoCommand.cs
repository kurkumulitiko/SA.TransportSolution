using MediatR;
using SA.Transport.Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SA.Transport.Core.Application.Features.Commands
{
    public class DeletePhotoRequest : IRequest
    {
        public Guid TransportId { get; set; }
        public DeletePhotoRequest(Guid transportId) => this.TransportId = transportId;
    }

    public class DeletePhotoHandler : IRequestHandler<DeletePhotoRequest>
    {
        private readonly IFileManager fileManager;
        private readonly IUnitOfWork unit;
        public DeletePhotoHandler(IUnitOfWork unit, IFileManager fileManager) =>
            (this.unit, this.fileManager) = (unit, fileManager);


        public Task<Unit> Handle(DeletePhotoRequest request, CancellationToken cancellationToken)
        {
            var transport = unit.TransportRepository.GetById(request.TransportId);
            transport.PhotoName = string.Empty;

            if (!string.IsNullOrEmpty(transport.PhotoName))
            {
                fileManager.DeleteFile(transport.PhotoName);
            }

            unit.TransportRepository.Update(transport);
            return Task.FromResult(Unit.Value);


        }
    }
}
