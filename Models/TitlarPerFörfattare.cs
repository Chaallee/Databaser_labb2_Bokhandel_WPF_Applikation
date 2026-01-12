using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel_WPF_Applikation.Models;

[Keyless]
public partial class TitlarPerFörfattare
{
    [StringLength(61)]
    public string Namn { get; set; } = null!;

    [StringLength(13)]
    public string? Ålder { get; set; }

    [StringLength(13)]
    public string? Titlar { get; set; }

    [StringLength(53)]
    public string? Lagervärde { get; set; }
}
