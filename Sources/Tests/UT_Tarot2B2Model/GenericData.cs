using StubContext;
using TarotDB;

namespace UT_Tarot2B2Model;

public class GenericData
{
	private static readonly IEnumerable<Tuple<bool, Type>> TarotDbContextEntities = new[]
	{
		Tuple.Create(true, typeof(PlayerEntity)),
		Tuple.Create(true, typeof(UserEntity)),
		Tuple.Create(true, typeof(GroupEntity)),
		Tuple.Create(true, typeof(GameEntity)),
		Tuple.Create(true, typeof(HandEntity)),
		Tuple.Create(false, typeof(TestEntity))
	};

	// for test an other context : create a new IEnumerable<Tuple<Type, bool>> with the entities you want to test
	// and use .Concat and .Select with your new List and new TarotDbContext
	public static IEnumerable<object[]> Data()
		=> TarotDbContextEntities
			.Select(item => new object[] {item.Item1, typeof(TarotDbContextStub), item.Item2});

	public static object CreateEntity(Type type, ulong id)
	{
		var entity = Activator.CreateInstance(type)!;
		
		foreach (var propertyInfo in type.GetProperties())
		{
			if (propertyInfo.PropertyType == typeof(string))
			{
				propertyInfo.SetValue(entity, "");
			}
		}
		
		var property = type.GetProperty("Id");
		property?.SetValue(entity, id);

		return entity;
	}
}