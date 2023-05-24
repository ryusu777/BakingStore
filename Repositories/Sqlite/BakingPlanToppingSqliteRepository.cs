using BakingStore.Data;
using BakingStore.Data.Entities;
using BakingStore.Data.Views;
using BakingStore.Pagination;
using BakingStore.Repositories.Interfaces;
using BakingStore.Services;

namespace BakingStore.Repositories.Sqlite;

public class BakingPlanToppingSqliteRepository : SqliteCrudService<BakingPlanTopping>, IBakingPlanToppingRepository
{
    public BakingPlanToppingSqliteRepository(BakingStoreSqliteContext context, EntityService entityService) : base(context, entityService)
    {
    }

	public async Task<PageResult<BakingPlanTopping>> FetchJoinPageAsync(PageRequest<VBakingPlanTopping> request)
	{
		ICollection<VBakingPlanTopping> qryResult = await (await _context.Set<VBakingPlanTopping>())
			.Where(request.WhereClause)
			.Skip(request.Page - 1 * request.RowsPerPage)
			.Take(request.RowsPerPage)
			.ToListAsync();

		return new PageResult<BakingPlanTopping>
		{
			RowsPerPage = request.RowsPerPage,
			Page = request.Page,
			TotalRows = qryResult.Count,
			Data = qryResult.Select(e => new BakingPlanTopping
				{
					Id = e.Id,
					BakingPlanId = e.BakingPlanId,
					Qty = e.Qty,
					ToppingId = e.ToppingId,
					Topping = new Topping
					{
						Id = e.ToppingId,
						AvailableStock = e.ToppingAvailableStock,
						Name = e.ToppingName,
						UomCode = e.ToppingUomCode
					}
				}).ToList()
		};
	}
}
