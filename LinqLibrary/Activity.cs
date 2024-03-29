﻿using System;

namespace LinqLibrary
{
    public class Activity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public int Attendees { get; set; }
    }
}
