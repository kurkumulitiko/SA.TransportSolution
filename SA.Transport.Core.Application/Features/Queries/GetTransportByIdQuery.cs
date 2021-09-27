using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SA.Transport.Core.Application.Features.Queries
{
    public class GetTransportByIdRequest : IRequest<GetTransportByIdResponse>
    {
        public Guid Id { get; set; }
        public GetTransportByIdRequest(Guid id) => this.Id = id;
    }

    public class GetTransportByIdResponse
    {
        public Guid Id { get; set; }
        public string MakeGE { get; set; }
        public string MakeEN { get; set; }
        public string ModelGE { get; set; }
        public string ModelEN { get; set; }
        public string VinCode { get; set; }
        public string Number { get; set; }
        public DateTime CreateDate { get; set; }
        public string Color { get; set; }
        public List<string> FuelTypes { get; set; }
        public List<string> Owners { get; set; }
        public string PhotoFileName { get; set; }

        public GetTransportByIdResponse(Domain.Model.Transport transport)
        {
            this.Id = transport.Id;
            this.MakeGE = transport.MakeGE;
            this.MakeEN = transport.MakeEN;
            this.ModelGE = transport.ModelGE;
            this.ModelEN = transport.ModelEN;
            this.VinCode = transport.VinCode;
            this.Number = transport.Number;
            this.CreateDate = transport.CreateDate;
            this.Color = transport.Color?.Name;
            this.FuelTypes = transport.FuelTypes.Select(x => x.FuelType.Type).ToList();
            this.Owners = transport.Owners.Select(x => $"{x.Person.FirstName} {x.Person.LastName}").ToList();
        }
    }


    public class GetTransportByIdHandler : IRequestHandler<GetTransportByIdRequest, GetTransportByIdResponse>
    {
        private readonly IUnitOfWork unit;

        public GetTransportByIdHandler(IUnitOfWork unit) => this.unit = unit;



        public Task<GetTransportByIdResponse> Handle(GetTransportByIdRequest request, CancellationToken cancellationToken)
        {
            var transport = unit.TransportRepository.GetById(request.Id);
            return Task.Run(() => new GetTransportByIdResponse(transport));
        }
    }

    public class GetTransportByIdValidator : AbstractValidator<GetTransportByIdRequest>
    {
        public GetTransportByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("მიუთითეთ ტრანსპორტის Id")
                .NotEmpty().WithMessage("მიუთითეთ ტრანსპორტის Id");

        }
    }



}
