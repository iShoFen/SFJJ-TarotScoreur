FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/GrpcService/GrpcService.csproj", "Api/GrpcService/"]
COPY ["Tarot2B2Model/Tarot2B2Model.csproj", "Tarot2B2Model/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["TarotDB/TarotDB.csproj", "TarotDB/"]
COPY ["Utils/Utils.csproj", "Utils/"]
COPY ["StubContext/StubContext.csproj", "StubContext/"]
RUN dotnet restore "Api/GrpcService/GrpcService.csproj"
COPY . .
WORKDIR "/src/Api/GrpcService"
RUN dotnet build "GrpcService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcService.dll"]
