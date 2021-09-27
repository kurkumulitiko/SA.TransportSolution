using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SA.Transport.Core.Application.Features.Commands
{
    public class AddTransportRequest : IRequest<Guid>
    {
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

    public class AddTransportHandler : IRequestHandler<AddTransportRequest, Guid>
    {
        private readonly IUnitOfWork unit;

        public AddTransportHandler(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public async Task<Guid> Handle(AddTransportRequest request, CancellationToken cancellationToken)
        {
            var transport = request.ToTransport();
            unit.TransportRepository.Create(transport);
            return await Task.FromResult(transport.Id);
        }
    }

    public class AddTransportValidator : AbstractValidator<AddTransportRequest>
    {
        public AddTransportValidator()
        {
            RuleFor(x => x.MakeGE)
                .NotEmpty().WithMessage("მიუთითეთ მარკის ქართული დასახელება")
                .MaximumLength(50).WithMessage("გამოიყენეთ მაქსიმუმ 50 სიმბოლო")
                .Matches("^[ა-ჰ]*$").WithMessage("მარკის ქართული დასახელება უნდა შედგებოდეს მხოლოდ ქართული სიმბოლოებისაგან");

            RuleFor(x => x.MakeEN)
               .NotEmpty().WithMessage("მიუთითეთ მარკის ლათინური დასახელება")
               .MaximumLength(50).WithMessage("გამოიყენეთ მაქსიმუმ 50 სიმბოლო")
               .Matches("^[a-zA-Z]*$").WithMessage("მარკის ლათინური დასახელება უნდა შედგებოდეს მხოლოდ ლათინური სიმბოლოებისაგან");

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
