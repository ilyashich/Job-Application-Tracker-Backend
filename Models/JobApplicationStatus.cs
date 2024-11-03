using System.Text.Json.Serialization;

namespace JobApplicationTracker.Models;

public enum JobApplicationStatus
{
    [JsonPropertyName("Just Applied")]
    JustApplied,
    Screening,
    Interview,
    Offer
}