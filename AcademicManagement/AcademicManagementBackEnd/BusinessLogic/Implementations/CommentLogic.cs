using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class CommentLogic : BaseLogic, ICommentLogic
    {
        private INotificationLogic _notificationLogic;

        public CommentLogic(IRepository repository, INotificationLogic notificationLogic)
            : base(repository)
        {
            _notificationLogic = notificationLogic;
        }


        public Comment AddComment(CommentDto commentDto)
        {
            var account = _repository.GetByFilter<Account>(x => x.UserCode == commentDto.UserCode);

            var comment = new Comment
            {
                Id = Guid.NewGuid(),
                Body = commentDto.Body,
                PostId = commentDto.PostId,
                AccountId = account.Id,
                Time = DateTime.Now
            };

            _repository.Insert(comment);
            _repository.Save();

            CreateNotification(commentDto, comment.Id);

            return comment;
         }

        private NotificationDto CreateNotification(CommentDto commentDto, Guid id)
        {
            var sender = new BaseUser();

            var account = _repository.GetByFilter<Account>(x => x.UserCode == commentDto.UserCode);

            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == commentDto.UserCode);

            var post = _repository.GetByFilter<Post>(x => x.Id == commentDto.PostId);

            var reciver = _repository.GetByFilter<Account>(x => x.Id == post.AccountId);

            var role = _repository.GetByFilter<UserRole>(x => x.Id == potentialUser.UserRoleId).Name;

            if (role == "Student")
            {
                sender = _repository.GetByFilter<Student>(x => x.PotentialUserId == potentialUser.Id);

            }
            if (role == "Professor")
            {
                sender = _repository.GetByFilter<Professor>(x => x.PotentialUserId == potentialUser.Id);
            }

            var notification = new NotificationDto
            {
                Title = "New comment",
                Body = sender.LastName + ' ' + sender.FirstName + " added a comment at your post",
                IsRead = false,
                ReciverId = reciver.PotentialUserId,
                SenderId = account.PotentialUserId,
                ItemId = id
            };


            _notificationLogic.Create(notification);
          

          
            return notification;

        }

        public ICollection<CommentDto> GetComents(Guid postId)
        {
            var commentDtos = new List<CommentDto>();
            var comments = _repository.GetAllByFilter<Comment>(x => x.PostId == postId);
            foreach(var comment in comments)
            {
                var account = _repository.GetByFilter<Account>(x => x.Id == comment.AccountId);

                var commentDto = new CommentDto
                {
                    Body = comment.Body,
                    UserCode = account.UserCode,
                    Time = comment.Time
                };

                commentDtos.Add(commentDto);
            }

            return commentDtos;
        }
    }
}
