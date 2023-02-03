using System.Collections.ObjectModel;
using AutoMapper;
using Google.Protobuf.Collections;
using Model.Players;

namespace GrpcService.extensions;

public class GroupExtension
{
    private static readonly MapperConfiguration Config = new (cfg =>
    {
        // cfg.CreateMap<ReadOnlyCollection<Player>, RepeatedField<UserReply>>()
        //    .ConvertUsing(src => new RepeatedField<UserReply>().AddRange(src.Select(p => p as User)

    });

    private static readonly Mapper Mapper = new (Config);
}
