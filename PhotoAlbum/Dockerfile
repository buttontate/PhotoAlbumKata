FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PhotoAlbum/PhotoAlbum.csproj", "PhotoAlbum/"]
RUN dotnet restore "PhotoAlbum/PhotoAlbum.csproj"
COPY . .
WORKDIR "/src/PhotoAlbum"
RUN dotnet build "PhotoAlbum.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhotoAlbum.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoAlbum.dll"]
