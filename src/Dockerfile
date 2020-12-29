FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
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
RUN dotnet dev-certs https -ep /https/aspnetapp.pfx -p crypticpassword
RUN dotnet dev-certs https
ENTRYPOINT ["dotnet", "invert-api.dll"]
