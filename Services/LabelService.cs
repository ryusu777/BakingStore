using BakingStore.Data.Entities;

namespace BakingStore.Services;

public static class LabelService
{
    public static Func<UOM, string> UOMLabel = (e) => e.UomCode + " - " + e.UomDesc;
}
