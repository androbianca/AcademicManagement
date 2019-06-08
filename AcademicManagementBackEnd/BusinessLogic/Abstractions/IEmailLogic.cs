using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstractions
{
    public interface IEmailLogic
    {
        Email Create(EmailDto emailDto);

        EmailDto GetById(Guid emailId);

        ICollection<EmailDto> GetAll();

       void SendEmail(string receiver, string subject, string body);
    }
}
