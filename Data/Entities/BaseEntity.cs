using SQLite;

namespace BakingStore.Data.Entities;

public class BaseEntity
{
	public BaseEntity()
	{
	}
	public BaseEntity(BaseEntity src)
	{
		Id = src.Id;
	}
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
}
