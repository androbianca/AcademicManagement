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
            var comment = new Comment
            {
                Body = commentDto.Body,
                PostId = commentDto.PostId,
                SenderId = commentDto.SenderId,
                Time = DateTime.Now
            };

            _repository.Insert(comment);
            _repository.Save();

           var notif = this.CreateNotification(comment);
            this._notificationLogic.Create(notif);

            return comment;
         }

        private NotificationDto CreateNotification(Comment comment)
        {
            var prof = _repository.GetByFilter<Professor>(x => x.Id == comment.SenderId);
            var stud = _repository.GetByFilter<Student>(x => x.Id == comment.SenderId);
            var sender = new BaseUser();
            var post = _repository.GetByFilter<Post>(x => x.Id == comment.PostId);
            var reciver = new BaseUser();
            var account = _repository.GetByFilter<Account>(x => x.Id == post.AccountId);

            if (stud != null)
            
            {
                sender = stud;
            }
            else
            {
                sender = prof;
            }

            var notification = new NotificationDto
            {
                Title = "New comment",
                Body = sender.LastName + ' ' + sender.FirstName + " added a comment at your post" ,
                IsRead = false,
                ReciverId = stud.PotentialUserId,
                SenderId = account.PotentialUserId,
                ItemId = comment.Id
            };

            return notification;

        }

        public ICollection<CommentDto> GetComents(Guid postId)
        {
            var commentDtos = new List<CommentDto>();
            var comments = _repository.GetAllByFilter<Comment>(x => x.PostId == postId);

            foreach(var comment in comments)
            {
                var commentDto = new CommentDto
                {
                    Body = comment.Body,
                    SenderId = comment.SenderId,
                    Time = comment.Time
                };

                commentDtos.Add(commentDto);
            }

            return commentDtos;
        }
    }
}
