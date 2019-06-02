using BusinessLogic.Abstractions;
using BusinessLogic.HubConfig;
using DataAccess.Abstractions;
using Entities;
using Microsoft.AspNetCore.SignalR;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class PostLogic : BaseLogic, IPostLogic
    {
        private IHubContext<SignalServer> _hubContext;
        private INotificationLogic _notificationLogic;

        public PostLogic(IRepository repository, IHubContext<SignalServer> hubContext, INotificationLogic notificationLogic)
            : base(repository)
        {
            _hubContext = hubContext;
            _notificationLogic = notificationLogic;
        }

        public Post Add(PostDto postDto)
        {
            var account = _repository.GetByFilter<Account>(x => x.UserCode == postDto.UserCode);
            var post = new Post
            {
                Body = postDto.Body,
                AccountId = account.Id,
                Id = Guid.NewGuid(),
                Time = DateTime.Now
            };

            _repository.Insert(post);
            _repository.Save();
            _hubContext.Clients.All.SendAsync("ceva", "");

            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == postDto.UserCode);

            var role = _repository.GetByFilter<UserRole>(x => x.Id == potentialUser.UserRoleId).Name;
            var sender = new BaseUser();
            if(role == "Student")
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
                Body =  sender.LastName + ' '+ sender.FirstName + " has posted on the wall.",
                IsRead = false,
                SenderId = account.PotentialUserId,
            };

            _notificationLogic.Create(notification);




            return post;
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
                    Body = post.Body,
                    UserCode = account.UserCode,
                    Time = post.Time,
                    Role = role.Name
                };

                postDtos.Add(postDto);

            }

            return postDtos;


        }



    }
}
