using Room.Domain.Common;

namespace Room.Domain.Entities;

public class MessageFile : GuidEntity
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public required string Extension { get; set; }
    public required string Url { get; set; }
    public string? LocalUrl { get; set; }
    public string? Preview { get; set; }
    public long? Size { get; set; }
    public bool? IsAudio { get; set; }
    public double? Duration { get; set; }
    public double? Progress { get; set; }
    public byte[]? Blob { get; set; }
}
