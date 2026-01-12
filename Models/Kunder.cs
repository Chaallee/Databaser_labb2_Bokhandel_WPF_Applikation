using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel_WPF_Applikation.Models;

[Table("Kunder")]
public partial class Kunder
{
    [Key]
    [Column("KundID")]
    public int KundId { get; set; }

    [StringLength(100)]
    public string Förnamn { get; set; } = null!;

    [StringLength(100)]
    public string Efternamn { get; set; } = null!;

    [StringLength(320)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string Telefonnummer { get; set; } = null!;

    [StringLength(300)]
    public string Leveransadress { get; set; } = null!;

    [StringLength(5)]
    public string Postnummer { get; set; } = null!;

    [StringLength(100)]
    public string Stad { get; set; } = null!;

    [InverseProperty("Kund")]
    public virtual ICollection<Ordrar> Ordrars { get; set; } = new List<Ordrar>();
}
