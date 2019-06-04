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
        private INotificationLogic _notificationLogic;

        public FeedbackLogic(IRepository repository, INotificationLogic notificationLogic)
            : base(repository)
        {
            _notificationLogic = notificationLogic;
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

            var notification  = this.CreateNotification(feedback);
            _notificationLogic.Create(notification);

            return feedback;
        }

        private NotificationDto CreateNotification(Feedback feedback)
        {
            var student = _repository.GetByFilter<Student>(x => x.Id == feedback.StudentId);
            var prof = _repository.GetByFilter<Professor>(x => x.Id == feedback.ProfessorId);
            var body = "";
            if (student==null)
            {
                 body = "Anonymous Feedback";
            }
            else
            {
                 body = student.LastName + ' ' + student.FirstName + " left feedback for you";
            }

            var notification = new NotificationDto
            {
                Title = "New feedback",
                Body = body,
                IsRead = false,
                ReciverId = prof.PotentialUserId,
                SenderId = student.PotentialUserId,
                ItemId = feedback.Id
            };

            return notification;

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
