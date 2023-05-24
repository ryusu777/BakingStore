using BakingStore.Data.Entities;
using BakingStore.Data.Views;
using BakingStore.Interfaces;
using BakingStore.Pagination;

namespace BakingStore.Repositories.Interfaces;

public interface IBakingPlanToppingRepository : ICrudService<BakingPlanTopping>
{
	public Task<PageResult<BakingPlanTopping>> FetchJoinPageAsync(PageRequest<VBakingPlanTopping> request);
}
