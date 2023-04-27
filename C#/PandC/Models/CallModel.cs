#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace PandC.Models;
public class CallModel
{
    public List<Join> Viewjoins { get; set; } = new List<Join>();
    public Join Join { get; set; }
    public List<P> ViewP { get; set; } = new List<P>();
    public P ? P{ get; set; }
    public List<C> ViewC { get; set; } = new List<C>();
    public C ? C { get; set; }
}