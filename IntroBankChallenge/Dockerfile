FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IntroBankChallenge/IntroBankChallenge.csproj", "IntroBankChallenge/"]
RUN dotnet restore "IntroBankChallenge/IntroBankChallenge.csproj"
COPY . .
WORKDIR "/src/IntroBankChallenge"
RUN dotnet build "IntroBankChallenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IntroBankChallenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IntroBankChallenge.dll"]
