using SQLite;

namespace BakingStore.Data.Entities;

public class UOMConversion : BaseEntity
{
	public UOMConversion()
	{
	}
	public UOMConversion(UOMConversion src) 
		: base(src)
	{
		Source = src.Source;
		Dest = src.Dest;
		Multiplier = src.Multiplier;
	}
	[Indexed]
	public string Source { get; set; }
	[Indexed]
	public string Dest { get; set; }
	public float Multiplier { get; set; }
}
