
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

COPY wait-for-it.sh /app/wait-for-it.sh
RUN chmod +x /app/wait-for-it.sh

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

RUN apt-get update && apt-get install -y \
    tzdata \
    locales 

ENV TZ=America/Sao_Paulo
# Environment Variables for ASP.NET Core
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
# Set the locale
    LC_ALL=pt_BR.UTF-8 \
    LANG=pt_BR.UTF-8 \
    LANGUAGE=pt_BR.UTF-8


CMD /app/wait-for-it.sh mysql:3306 -- dotnet CadastroCurriculo.dll

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","CadastroCurriculo.dll"]