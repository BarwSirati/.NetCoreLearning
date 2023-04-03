FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ENV PORT 8081
WORKDIR /app
EXPOSE $PORT

ENV ASPNETCORE_URLS=http://+:${PORT}

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FoodPool.csproj", "./"]
RUN dotnet restore "FoodPool.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "FoodPool.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodPool.csproj" -c Release -o /app/publish /p:UseAppHost=false 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodPool.dll"]
