FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY cat-api.sln ./
COPY cat-api/cat-api.csproj cat-api/
COPY build.dcproj ./
RUN ls -alh
RUN dotnet restore -nowarn:msb3202,nu1503 cat-api/cat-api.csproj
COPY . .
WORKDIR /src/cat-api
RUN dotnet build -c Release -o /app cat-api.csproj

FROM build AS publish
RUN dotnet publish -c Release -o /app cat-api.csproj

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "net-core.dll"]
