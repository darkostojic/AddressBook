#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["AddressBook/AddressBook.csproj", "AddressBook/"]
COPY ["DataStorage/DataStorage.csproj", "DataStorage/"]
COPY ["DataStorage.PostgreSQL/DataStorage.PostgreSQL.csproj", "DataStorage.PostgreSQL/"]
COPY ["Commons/Commons.csproj", "Commons/"]
RUN dotnet restore "AddressBook/AddressBook.csproj"
COPY . .
WORKDIR "/src/AddressBook"
RUN dotnet build "AddressBook.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AddressBook.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AddressBook.dll"]