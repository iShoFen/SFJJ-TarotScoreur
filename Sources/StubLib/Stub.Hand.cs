using Model.Games;

namespace StubLib;

public partial class Stub
{
    public async Task<Hand?> GetHandById(ulong handId)
        => await Task.FromResult(_handList.FirstOrDefault(h => h.Id == handId));
}