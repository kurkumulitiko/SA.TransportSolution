using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SA.Transport.Core.Application.Features.Commands
{
    public class DeleteTransportRequest : IRequest
    {
        public Guid Id { get; set; }
        public DeleteTransportRequest(Guid id) => this.Id = id;
    }

    public class DeleteTransportHandler : IRequestHandler<DeleteTransportRequest>
    {
        private readonly IUnitOfWork unit;
        public DeleteTransportHandler(IUnitOfWork unit) => this.unit = unit;

        public Task<Unit> Handle(DeleteTransportRequest request, CancellationToken cancellationToken)
        {
            unit.TransportRepository.Delete(request.Id);
            return Task.FromResult(Unit.Value);
        }



        public class DeleteTransportValidator : AbstractValidator<DeleteTransportRequest>
        {
            public DeleteTransportValidator()
            {
                RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("მიუთითეთ ტრანსპორტის Id")
                    .Must(x => x != default).WithMessage("მიუთითეთ ტრანსპორტის Id");

            }
        }
    }
}
