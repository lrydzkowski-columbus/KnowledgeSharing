FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG HUSKY=0
WORKDIR /src
COPY ["./KnowledgeSharing.Core/.", "KnowledgeSharing.Core/"]
COPY ["./KnowledgeSharing.Persistence.Db/.", "KnowledgeSharing.Persistence.Db/"]
COPY ["./KnowledgeSharing.WebApi/.", "KnowledgeSharing.WebApi/"]
WORKDIR "/src/KnowledgeSharing.WebApi"
RUN dotnet restore "KnowledgeSharing.WebApi.csproj"
RUN dotnet build "KnowledgeSharing.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
ARG HUSKY=0
RUN dotnet publish "KnowledgeSharing.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KnowledgeSharing.WebApi.dll"]