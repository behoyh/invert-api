FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY invert-api.csproj ./
RUN dotnet restore "./invert-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "invert-api.csproj" -c Development -o /app/build

FROM build AS publish
RUN dotnet publish "invert-api.csproj" -c Development -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p crypticpassword
ENTRYPOINT ["dotnet", "invert-api.dll"]
