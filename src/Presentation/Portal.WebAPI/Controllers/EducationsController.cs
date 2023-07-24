﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Educations.CreateEducation;
using Portal.Application.Features.Commands.Educations.DeleteEducation;
using Portal.Application.Features.Commands.Educations.UpdateEducation;
using Portal.Application.Features.Queries.Educations.GetEducationById;
using Portal.Application.Features.Queries.Seminars.GetSeminarParticipants;

namespace Portal.WebAPI.Controllers
{
    [Route("api/educations")]
    [ApiController]
    [Authorize(Roles = "Organiser")]
    public class EducationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EducationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEducationRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetEducationByIdRequest request)
        {
            GetEducationByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteEducationRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateEducationRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpGet("{Id}/participants")]
        public async Task<IActionResult> GetParticipants([FromRoute] GetEducationByIdRequest request)
        {
            GetEducationByIdResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
