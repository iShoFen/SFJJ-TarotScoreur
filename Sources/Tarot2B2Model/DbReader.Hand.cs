using Microsoft.EntityFrameworkCore;
using Model.Games;
using TarotDB;

namespace Tarot2B2Model;

public partial class DbReader
{
    public async Task<Hand?> GetHandById(ulong handId)
    {
        Mapper.Reset();
        return (await Set<HandEntity>()
                .Include(h => h.Biddings)
                .ThenInclude(b => b.Player)
                .FirstOrDefaultAsync(h => h.Id == handId))
            ?.ToModel();
    }
}