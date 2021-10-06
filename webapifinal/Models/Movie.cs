﻿using System;
using System.Collections.Generic;

#nullable disable

namespace webapifinal.Models
{
    public partial class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string BoxOffice { get; set; }
        public string Active { get; set; }
        public DateTime? DateOfLaunch { get; set; }
        public string Genre { get; set; }
        public string HasTeaser { get; set; }
    }
}
