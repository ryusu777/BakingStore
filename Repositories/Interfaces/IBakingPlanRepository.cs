using BakingStore.Data.Entities;
using BakingStore.Interfaces;

namespace BakingStore.Repositories.Interfaces;

public interface IBakingPlanRepository : ICrudService<BakingPlan>
{
	public Task<ICollection<BakingPlan>> FetchBakingPlaningData(DateTime date);
	public Task<ICollection<DoughingAdjustment>> FetchDoughingAdjustmentData(string date);
}
