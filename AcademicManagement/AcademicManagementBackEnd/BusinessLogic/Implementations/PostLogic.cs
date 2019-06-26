using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class PostLogic : BaseLogic, IPostLogic
    {
        private INotificationLogic _notificationLogic;

        public PostLogic(IRepository repository, INotificationLogic notificationLogic)
            : base(repository)
        {
            _notificationLogic = notificationLogic;
        }

        public Post Add(PostDto postDto)
        {
            var sender = new BaseUser();
            var account = _repository.GetByFilter<Account>(x => x.UserCode == postDto.UserCode);

            if (account == null)
            {
                return null;
            }

            var post = new Post
            {
                Id = Guid.NewGuid(),
                Body = postDto.Body,
                AccountId = account.Id,
                Time = DateTime.Now
            };

            _repository.Insert(post);
            _repository.Save();

            CreateNotif(account, postDto.UserCode);
            return post;
        }


        private NotificationDto CreateNotif(Account account, string userCode)
        {
            var sender = new BaseUser();
            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == userCode);
            var role = _repository.GetByFilter<UserRole>(x => x.Id == potentialUser.UserRoleId).Name;

            if(potentialUser == null || role == null)
            {
                return null;
            }

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
                ReciverId = Guid.Empty,
                Title = "New post on wall.",
                Body = sender.LastName + ' ' + sender.FirstName + " has posted on the wall.",
                IsRead = false,
                SenderId = account.PotentialUserId,
            };

            _notificationLogic.Create(notification);

            return notification;
        }



        public ICollection<PostDto> GetAll()
        {
            var postDtos = new List<PostDto>();
            var posts = _repository.GetAll<Post>();

            foreach (var post in posts)
            {
                var account = _repository.GetByFilter<Account>(x => x.Id == post.AccountId);
                var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == account.UserCode);
                var role = _repository.GetByFilter<UserRole>(x => x.Id == potentialUser.UserRoleId);
                var postDto = new PostDto
                {
                    Id = post.Id,
                    Body = post.Body,
                    UserCode = account.UserCode,
                    Time = post.Time,
                };

                postDtos.Add(postDto);

            }

            return postDtos;

        }


    }
}
