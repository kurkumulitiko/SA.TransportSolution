using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SA.Transport.Core.Application.Features.Commands
{
    public class UpdateTransportRequest : IRequest
    {
        public Guid Id { get; set; }
        public string MakeGE { get; set; }
        public string MakeEN { get; set; }
        public string ModelGE { get; set; }
        public string ModelEN { get; set; }
        public string VinCode { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid ColorId { get; set; }
        //public ICollection<TransportFuelType> FuelTypes { get; set; }
        //public ICollection<TransportOwner> Owners { get; set; }

        public Domain.Model.Transport ToTransport()
        {
            var transport = new Domain.Model.Transport
            {
                Id = this.Id,
                MakeGE = this.MakeGE,
                MakeEN = this.MakeEN,
                ModelGE = this.ModelGE,
                ModelEN = this.ModelEN,
                VinCode = this.VinCode,
                Number = this.Number,
                CreateDate = this.CreateDate,
                ColorId = this.ColorId
            };

            return transport;
        }
    }

    public class UpdateTransportHandler : IRequestHandler<UpdateTransportRequest>
    {
        private readonly IUnitOfWork unit;

        public UpdateTransportHandler(IUnitOfWork unit) => this.unit = unit;

        public Task<Unit> Handle(UpdateTransportRequest request, CancellationToken cancellationToken)
        {
            var transport = request.ToTransport();
            unit.TransportRepository.Update(transport);
            return Task.FromResult(Unit.Value);
        }
    }

    public class UpdateTransportValidator : AbstractValidator<UpdateTransportRequest>
    {
        public UpdateTransportValidator()
        {
            RuleFor(x => x.Id)
                   .NotEmpty().WithMessage("მიუთითეთ ტრანსპორტის Id")
                   .Must(x => x != default).WithMessage("მიუთითეთ ტრანსპორტის Id");

            RuleFor(x => x.MakeGE)
                .NotNull().WithMessage("მიუთითეთ მარკის ქართული დასახელება")
                .MaximumLength(50).WithMessage("გამოიყენეთ მაქსიმუმ 50 სიმბოლო");

            RuleFor(x => x.MakeEN)
               .NotNull().WithMessage("მიუთითეთ მარკის ლათინური დასახელება")
               .MaximumLength(50).WithMessage("გამოიყენეთ მაქსიმუმ 50 სიმბოლო");

            RuleFor(x => x.ModelGE)
                .NotNull().WithMessage("მიუთითეთ მოდელის ქართული დასახელება")
                .MaximumLength(50).WithMessage("გამოიყენეთ მაქსიმუმ 50 სიმბოლო");

            RuleFor(x => x.ModelEN)
                .NotNull().WithMessage("მიუთითეთ მოდელის ლათინური დასახელება")
                .MaximumLength(50).WithMessage("გამოიყენეთ მაქსიმუმ 50 სიმბოლო");

            RuleFor(x => x.Number)
              .NotNull().WithMessage("მიუთითეთ ნომერი")
              .MaximumLength(100).WithMessage("გამოიყენეთ მაქსიმუმ 20 სიმბოლო");

            RuleFor(x => x.VinCode)
               .NotNull().WithMessage("მიუთითეთ ვინკოდი")
               .MaximumLength(100).WithMessage("გამოიყენეთ მაქსიმუმ 100 სიმბოლო");


        }
    }
}