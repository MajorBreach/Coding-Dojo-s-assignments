#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace PandC.Models;
public class Join
{
    [Key]
    public int JoinId { get; set; }
    public int CategoryId { get; set; } 
    public int ProductId { get; set; }
    public P ? P { get; set; }
    public C ? C { get; set; }

}