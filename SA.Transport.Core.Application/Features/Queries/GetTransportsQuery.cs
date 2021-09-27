using MediatR;
using SA.Transport.Core.Application.Common.Filters;
using SA.Transport.Core.Application.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SA.Transport.Core.Application.Features.Queries
{
    public class GetTransportsRequest : IRequest<(IEnumerable<TransportResponse> transports, PageResponse pageResponse)>
    {
        public PageRequest pageRequest;
        public TransportFilter transportFilter;
        public string orderBy;

        public GetTransportsRequest(PageRequest pageRequest, TransportFilter transportFilter, string orderBy = "") =>
                                (this.pageRequest, this.transportFilter, this.orderBy) = (pageRequest, transportFilter, orderBy);


    }

    public class TransportResponse
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

        public TransportResponse(Domain.Model.Transport transport)
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


    public class GetTransportsHandler : IRequestHandler<GetTransportsRequest, (IEnumerable<TransportResponse> transports, PageResponse pageResponse)>
    {
        private readonly IUnitOfWork unit;

        public GetTransportsHandler(IUnitOfWork unit) => this.unit = unit;

        public Task<(IEnumerable<TransportResponse> transports, PageResponse pageResponse)> Handle(GetTransportsRequest request, CancellationToken cancellationToken)
        {
            var transports = unit.TransportRepository.GetAll(request.pageRequest, out PageResponse pageResponse, request.orderBy, request.transportFilter);
            var transportsResponse = (IEnumerable<TransportResponse>)transports.ToList().Select(x => new TransportResponse(x)).ToList();
            return Task.Run(() => (transportsResponse, pageResponse));
        }
    }

}
