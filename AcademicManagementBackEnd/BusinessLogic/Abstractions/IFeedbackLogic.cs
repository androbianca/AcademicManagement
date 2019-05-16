using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
   public interface IFeedbackLogic
   {
       Feedback Add(FeedbackDto feedbackDto);
       List<FeedbackDto> GetByProfId(Guid profId);
   }
}
