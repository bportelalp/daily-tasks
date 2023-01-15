using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.Adapters.Identity.ORM.Entities;

[Table("Address", Schema = "identity")]
public partial class Address
{
    [Key]
    public Guid AddressId { get; set; }

    [Column("Address")]
    public string Address1 { get; set; } = null!;

    public int ZipCode { get; set; }

    public string Localty { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string Country { get; set; } = null!;

    [ForeignKey("AddressFk")]
    [InverseProperty("AddressFks")]
    public virtual ICollection<AspNetUser> UserFks { get; } = new List<AspNetUser>();
}
