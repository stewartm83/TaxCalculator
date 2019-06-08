FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Calculator.Web/Calculator.Web.csproj", "Calculator.Web/"]
RUN dotnet restore "Calculator.Web/Calculator.Web.csproj"
COPY . .
WORKDIR "/src/Calculator.Web"
RUN dotnet build "Calculator.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Calculator.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Calculator.Web.dll"]