using SQLite;

namespace BakingStore.Data.Entities;

public class UOM
{
	public UOM()
	{
	}
	public UOM(UOM src)
	{
		UomCode = src.UomCode;
		UomDesc = src.UomDesc;
	}
    [PrimaryKey]
    public string UomCode { get; set; }
    public string UomDesc { get; set; }
}
