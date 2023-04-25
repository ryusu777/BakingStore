using SQLite;

namespace BakingStore.Data.Entities;

public class UOMConversion
{
	[PrimaryKey]
	public string Source { get; set; }
	[PrimaryKey]
	public string Dest { get; set; }
	public float Multiplier { get; set; }
}
