using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BP.ShoppingTracker.Adapters.Identity.ORM.Entities;

[Table("UserPersonalData", Schema = "identity")]
public partial class UserPersonalDatum
{
    [Key]
    [Column("UserFK")]
    public string UserFk { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Nationality { get; set; } = null!;

    public string? Identification { get; set; }

    [ForeignKey("UserFk")]
    [InverseProperty("UserPersonalDatum")]
    public virtual AspNetUser UserFkNavigation { get; set; } = null!;
}
