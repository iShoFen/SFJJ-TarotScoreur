FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/RestController/RestController.csproj", "Api/RestController/"]
COPY ["StubContext/StubContext.csproj", "StubContext/"]
COPY ["TarotDB/TarotDB.csproj", "TarotDB/"]
COPY ["Tarot2B2Model/Tarot2B2Model.csproj", "Tarot2B2Model/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["Utils/Utils.csproj", "Utils/"]
RUN dotnet restore "Api/RestController/RestController.csproj"
COPY . .
WORKDIR "/src/Api/RestController"
RUN dotnet build "RestController.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RestController.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestController.dll"]
