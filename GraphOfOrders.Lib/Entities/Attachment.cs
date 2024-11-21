using System;
using GraphOfOrders.Lib.Enums;

namespace GraphOfOrders.Lib.Entities;

/// <summary>
/// Represents an attachment with associated metadata.
/// </summary>
public sealed record Attachment
{
    /// <summary>
    /// Gets or sets the ID of the attachment.
    /// </summary>
    public string Id { get; } = string.Empty;

    /// <summary>
    /// Enum of Types Of a Documents
    /// </summary>
    public TypesOfDocument Type { get; } = TypesOfDocument.Default;
    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    public string FileName { get; } = string.Empty;

    /// <summary>
    /// Gets or sets the binary data of the attachment.
    /// </summary>
    public byte[] Data { get; } = Array.Empty<byte>();

    /// <summary>
    /// Gets or sets the MIME type of the attachment.
    /// </summary>
    public string ContentType { get; } = string.Empty;

    /// <summary>
    /// Gets or sets the size of the attachment in bytes.
    /// </summary>
    public long Size => Data.Length;

    /// <summary>
    /// Initializes a new instance of the <see cref="Attachment"/> record.
    /// </summary>
    /// <param name="id">The ID of the attachment.</param>
    /// <param name="fileName">The name of the file.</param>
    /// <param name="data">The binary data of the attachment.</param>
    /// <param name="contentType">The MIME type of the attachment.</param>
    public Attachment(string id, string fileName, byte[] data, string contentType, TypesOfDocument type = TypesOfDocument.Default)
    {
        Id = id;
        FileName = fileName;
        Data = data;
        ContentType = contentType;
        Type = type;
    }

    /// <summary>
    /// Returns a string representation of the attachment, including its ID and file name.
    /// </summary>
    /// <returns>A string representation of the attachment.</returns>
    public override string ToString() => $"{FileName} (ID: {Id}, Size: {Size} bytes, ContentType: {ContentType})";
}