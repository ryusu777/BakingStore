using SQLite;

namespace BakingStore.Data.Entities;

public class UOM : BaseEntity
{
	public UOM()
	{
	}
	public UOM(UOM src) 
		: base(src)
	{
		UomCode = src.UomCode;
		UomDesc = src.UomDesc;
	}
	[Indexed]
    public string UomCode { get; set; }
    public string UomDesc { get; set; }
}
