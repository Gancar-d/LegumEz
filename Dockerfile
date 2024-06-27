FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 7161

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY /Server/ .
RUN dotnet restore "src/LegumEz.WebApi/LegumEz.WebApi.csproj"
RUN dotnet build "src/LegumEz.WebApi/LegumEz.WebApi.csproj" -c Release -o /app/build
RUN dotnet tool install --version 6.0.9 --global dotnet-ef

FROM build AS publish
COPY --from=build /src/data /app/data
RUN dotnet publish "src/LegumEz.WebApi/LegumEz.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
COPY --from=publish /app/publish .
COPY --from=publish /app/data ./data
ENTRYPOINT ["dotnet", "LegumEz.WebApi.dll"]