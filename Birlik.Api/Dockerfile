FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["Birlik.Api/Birlik.Data.csproj", "Birlik.Data/"]
COPY ["Birlik.Api/Birlik.Domain.csproj", "Birlik.Domain/"]
COPY ["Birlik.Api/Birlik.Api.csproj", "Birlik.Api/"]
RUN dotnet restore "Birlik.Api/Birlik.Api.csproj"
COPY . .
WORKDIR "/src/Birlik.Api"
RUN dotnet build "Birlik.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Birlik.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Birlik.Api.dll"]