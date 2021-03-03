﻿using System.Text.Json.Serialization;

namespace RMotownFestival.DAL.Entities
{
    public class Stage
    {
        public int Id { get; set; }

        public int FestivalId { get; set; }
        [JsonIgnore]
        public Festival Festival { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}