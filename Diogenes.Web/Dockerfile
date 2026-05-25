FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG TARGETARCH
WORKDIR /src
COPY ["Diogenes.Web/Diogenes.Web.csproj", "Diogenes.Web/"]
RUN dotnet restore "Diogenes.Web/Diogenes.Web.csproj" -a $TARGETARCH
COPY . .
WORKDIR "/src/Diogenes.Web"
RUN dotnet build "Diogenes.Web.csproj" -c Release -o /app/build -a $TARGETARCH

FROM build AS publish
ARG TARGETARCH
RUN dotnet publish "Diogenes.Web.csproj" -c Release -o /app/publish -a $TARGETARCH

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Diogenes.Web.dll"]
