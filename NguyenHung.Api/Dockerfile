FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["NguyenHung.Api/NguyenHung.Api.csproj", "NguyenHung.Api/"]
COPY ["NguyenHung.DAL/NguyenHung.DAL.csproj", "NguyenHung.DAL/"]
COPY ["NguyenHung.Common/NguyenHung.Common.csproj", "NguyenHung.Common/"]
COPY ["NguyenHung.Service/NguyenHung.Service.csproj", "NguyenHung.Service/"]
RUN dotnet restore "NguyenHung.Api/NguyenHung.Api.csproj"
COPY . .
WORKDIR "/src/NguyenHung.Api"
RUN dotnet build "NguyenHung.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NguyenHung.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NguyenHung.Api.dll"]
