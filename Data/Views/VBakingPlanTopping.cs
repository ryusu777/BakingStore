namespace BakingStore.Data.Views;

public class VBakingPlanTopping
{
    public int Id { get; set; }
    public int BakingPlanId { get; set; }
    public int ToppingId { get; set; }
    public int Qty { get; set; }
    public string ToppingName { get; set; }
    public string ToppingUomCode { get; set; }
    public float ToppingAvailableStock { get; set; }
}
