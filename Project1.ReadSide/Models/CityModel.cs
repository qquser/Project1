﻿using Project1.Common.Enums;
using Project1.ReadSide.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.ReadSide.Models
{
    public class CityModel : BaseModel
    {
        private CityModel()
        {
        }
        public CityModel(Guid id) : base(id)
        {
        }

        public string Name { get; set; }

        public CityStatus Status { get; set; }

        public ICollection<WorkshopModel> Workshops { get; set; }
    }
}
