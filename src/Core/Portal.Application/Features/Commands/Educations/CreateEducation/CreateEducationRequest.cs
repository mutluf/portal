﻿using MediatR;
using Portal.Application.DTOs;

namespace Portal.Application.Features.Commands.Educations.CreateEducation
{
    public class CreateEducationRequest: IRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsPublic { get; set; } = true;
        public bool IsCanceled { get; set; } = false;
        public DateTime StartTime { get; set; }
        public int UserProfileId { get; set; }
    }
}
