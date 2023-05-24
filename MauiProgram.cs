using Microsoft.Extensions.Logging;
using BakingStore.Data;
using BakingStore.Services;
using BakingStore.Repositories.Sqlite;
using BakingStore.Repositories.Interfaces;

namespace BakingStore;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		SQLitePCL.Batteries_V2.Init();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddTransient<BakingStoreSqliteContext>();
		builder.Services.AddTransient(typeof(SqliteCrudService<>));
		builder.Services.AddTransient<IIngredientRepository, IngredientSqliteRepository>();
		builder.Services.AddTransient<IToppingRepository, ToppingSqliteRepository>();
		builder.Services.AddTransient<IUOMRepository, UOMSqliteRepository>();
		builder.Services.AddTransient<IUOMConversionRepository, UOMConversionSqliteRepository>();
		builder.Services.AddTransient<IBaseRecipeRepository, BaseRecipeSqliteRepository>();
		builder.Services.AddTransient<IBaseRecipeIngredientRepository, BaseRecipeIngredientSqliteRepository>();
		builder.Services.AddTransient<IBakingPlanRepository, BakingPlanSqliteRepository>();
		builder.Services.AddTransient<EntityService>();
		builder.Services.AddSingleton<ToastService>();
		return builder.Build();
	}
}
