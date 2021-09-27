using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SA.Transport.Core.Application.Common.Filters;
using SA.Transport.Core.Application.Common.Paging;
using SA.Transport.Core.Application.Features.Commands;
using SA.Transport.Core.Application.Features.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SA.Transport.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransportsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] TransportFilter transportFilter = null,
            [FromQuery] string orderBy = null,
            [FromQuery] PageRequest pageRequest = null)
        {
            var result = mediator.Send(new GetTransportsRequest(pageRequest, transportFilter, orderBy)).Result;

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(result.pageResponse));

            return Ok(result.transports);
        }

        [HttpGet("{id}", Name = "getById")]
        public async Task<GetTransportByIdResponse> Get(Guid id)
        {
            return await mediator.Send(new GetTransportByIdRequest(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddTransportRequest request)
        {
            var result = await mediator.Send(request);
            return CreatedAtRoute("getById", new { id = result }, result);
        }


        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateTransportRequest request)
        {
            return Ok(mediator.Send(request).Result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(mediator.Send(new DeleteTransportRequest(id)).Result);
        }


        [HttpPost("UploadPhoto")]
        public IActionResult AddPhoto([FromForm] UploadPhotoRequest request)
        {
            return Ok(mediator.Send(request));
        }

        [HttpDelete("DeletePhoto")]
        public IActionResult DeletePhoto(Guid transportId)
        {
            return Ok(mediator.Send(new DeletePhotoRequest(transportId)));
        }
    }
}
