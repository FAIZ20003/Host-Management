using System;
using System.Collections.Generic;

namespace AssetManager.Models;

public partial class Hostdetail
{
    public string DeviceId { get; set; } = null!;

    public string HostName { get; set; } = null!;

    public string HostGroup { get; set; } = null!;

    public string MacAddress { get; set; } = null!;

    public string IpAddress { get; set; } = null!;

    public string HostUser { get; set; } = null!;

    public string? HostStatus { get; set; }
}
