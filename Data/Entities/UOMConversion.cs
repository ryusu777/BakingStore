using SQLite;

namespace BakingStore.Data.Entities;

public class UOMConversion
{
	public UOMConversion()
	{
	}
	public UOMConversion(UOMConversion src)
	{
		Source = src.Source;
		Dest = src.Dest;
		Multiplier = src.Multiplier;
	}

	[PrimaryKey]
	public string Source { get; set; }
	[PrimaryKey]
	public string Dest { get; set; }
	public float Multiplier { get; set; }
}
