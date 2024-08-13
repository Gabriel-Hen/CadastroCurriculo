
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
COPY ./src/CadastroCurriculo/CadastroCurriculo.csproj ./src/CadastroCurriculo/
COPY ./src/Core/Core.csproj ./src/Core/
COPY ./src/DataBase/DataBase.csproj ./src/DataBase/

# Restore in a separate layer
RUN dotnet restore ./src/CadastroCurriculo/CadastroCurriculo.csproj  
RUN dotnet restore ./src/Core/Core.csproj 
RUN dotnet restore ./src/DataBase/DataBase.csproj 

# Copy the rest of the application
COPY . .
RUN dotnet build ./src/CadastroCurriculo/CadastroCurriculo.csproj -c Release -o /app/build

FROM build AS publish
# Publish the application
RUN dotnet publish ./src/CadastroCurriculo \
    --no-restore \
    # /p:PublishReadyToRun=true \
    -c Release \
    -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","CadastroCurriculo.dll"]