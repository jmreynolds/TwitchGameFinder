using System;
using Newtonsoft.Json;

namespace Core.Models
{
    public class StreamModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public string UserId { get; set; }
        [JsonProperty(PropertyName = "game_id")]
        public string GameId { get; set; }
        [JsonProperty(PropertyName = "community_ids")]
        public string[] CommunityIds { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "viewer_count")]
        public int ViewerCount { get; set; }
        [JsonProperty(PropertyName = "started_at")]
        public DateTime StartedAt { get; set; }
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }
        [JsonProperty(PropertyName = "thumbnail_url")]
        public string ThumbnailUrl { get; set; }
    }
}