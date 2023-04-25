using SQLite;

namespace BakingStore.Data.Entities;

public class UOM
{
    [PrimaryKey]
    public string UomCode { get; set; }
    public string UomDesc { get; set; }
}
