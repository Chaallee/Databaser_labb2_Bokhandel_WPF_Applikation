using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Bokhandel_WPF_Applikation.Models;

[Table("Ordrar")]
public partial class Ordrar
{
    [Key]
    public int Ordernummer { get; set; }

    [Column("KundID")]
    public int KundId { get; set; }

    [Precision(0)]
    public DateTime Orderdatum { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = null!;

    [ForeignKey("KundId")]
    [InverseProperty("Ordrars")]
    public virtual Kunder Kund { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<Orderdetaljer> Orderdetaljers { get; set; } = new List<Orderdetaljer>();
}
