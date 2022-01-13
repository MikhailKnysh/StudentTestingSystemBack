FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./STS.Api.csproj", "./STS.Api/"]
RUN dotnet restore "STS.Api.csproj"
COPY . .
WORKDIR "/src/STS.Api"
RUN dotnet build "STS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "STS.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "STS.Api.dll"]
