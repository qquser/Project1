﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Application.API.Models.Workshop
{
    public class AddWorkshopModel
    {
        public Guid CommandId { get; set; }

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Guid CityId { get; set; }
    }
}