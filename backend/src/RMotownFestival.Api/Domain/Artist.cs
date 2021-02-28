using System;

namespace RMotownFestival.Api.Domain
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Uri Website { get; set; }
    }

}
