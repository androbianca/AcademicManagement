using System;
using System.Collections.Generic;
using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class FeedbackLogic : BaseLogic, IFeedbackLogic
    {
        public FeedbackLogic(IRepository repository)
            : base(repository)
        {
        }

        public Feedback Add(FeedbackDto feedbackDto)
        {
            var feedback = new Feedback
            {
                Id = Guid.NewGuid(),
                Body = feedbackDto.Body,
                StudentId = feedbackDto.StudentId,
                ProfessorId = feedbackDto.ProfessorId
            };

            _repository.Insert(feedback);
            _repository.Save();

            return feedback;
        }

        public List<FeedbackDto> GetByProfId(Guid profId)
        {
            var feedback = _repository.GetAllByFilter<Feedback>(x => x.ProfessorId == profId);
            var feedbackDtos = new List<FeedbackDto>();
            foreach (var value in feedback)
            {
                var feedbackDto = new FeedbackDto
                {
                    Body = value.Body,
                    StudentId = value.StudentId,
                    ProfessorId = value.ProfessorId
                };

                feedbackDtos.Add(feedbackDto);

            }

            return feedbackDtos;
        }
    }
}
