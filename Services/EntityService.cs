using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace BakingStore.Services;

public class EntityService
{
	private readonly bool _isLocalDatabase;
	public EntityService()
	{
		_isLocalDatabase = true;
	}
	public T CreateInstance<T>()
	{
		return (T)Activator.CreateInstance(
			GetTypesInNamespace(Assembly.GetExecutingAssembly(), _isLocalDatabase ? "BakingStore.Data.Sqlite" : "BakingStore.Data.Entities")
				.First(e => e.IsAssignableTo(typeof(T)))
		);
	}

	public Type GetEntityClass<T>()
	{
		return GetTypesInNamespace(Assembly.GetExecutingAssembly(), _isLocalDatabase ? "BakingStore.Data.Sqlite" : "BakingStore.Data.Entities")
				.First(e => e.IsAssignableTo(typeof(T)));
	}

	private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
	{
		return
		  assembly.GetTypes()
				  .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
				  .ToArray();
	}
}
