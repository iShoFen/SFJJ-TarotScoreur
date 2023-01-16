namespace UT_Tarot2B2Model;

public class TestEntity
{
	public ulong Id { get; set; }
	public string Name { get; set; } = null!;
	public string Description { get; set; } = null!;
	public DateTime Created { get; set; }
	public DateTime Modified { get; set; }
}