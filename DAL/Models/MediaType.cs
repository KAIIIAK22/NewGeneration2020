﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MediaType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Media> Media { get; set; } = new List<Media>();
    }
}
