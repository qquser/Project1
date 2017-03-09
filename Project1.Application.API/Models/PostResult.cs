﻿using System;

namespace Project1.Application.API.Models
{
    public class PostResult<T>
    {
        public string CommandName => nameof(T);
        public Guid CommandId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}