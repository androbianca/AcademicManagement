﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class NotificationDto
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public bool IsRead { get; set; } = false;
        public Guid UserId { get; set; }
    }
}