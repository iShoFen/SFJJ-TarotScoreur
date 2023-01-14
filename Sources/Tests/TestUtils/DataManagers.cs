using Model.Data;
using StubContext;
using StubLib;
using Tarot2B2Model;

namespace TestUtils;

internal static class DataManagers
{
	public static readonly IReader[] Loaders = {
		new Stub(),
		new DbReader(typeof(TarotDbContextStub), "DataSource=:memory:")
	};
	
	public static readonly IWriter[] Savers = {
		new DbWriter(typeof(TarotDbContextStub), "DataSource=:memory:")
	};
}