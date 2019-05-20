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

        public PostLogic(IRepository repository, IHubContext<SignalServer> hubContext)
            : base(repository)
        {
            _hubContext = hubContext;
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

            return post;
        }

        public ICollection<PostDto> GetAll()
        {
            var postDtos = new List<PostDto>();
            var posts = _repository.GetAll<Post>();

            foreach(var post in posts)
            {
                var account = _repository.GetByFilter<Account>(x => x.Id == post.AccountId);
                var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == account.UserCode);
                var role = _repository.GetByFilter<UserRole>(x => x.Id == potentialUser.UserRoleId);
                var postDto = new PostDto
                {
                    Body = post.Body,
                    UserCode = account.UserCode,
                    Time = DateTime.Now,
                    Role = role.Name
                };

                postDtos.Add(postDto);

            }

            return postDtos;


        } 



    }
}
