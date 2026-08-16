FROM mcr.microsoft.com/dotnet/aspnet:10.0.5-noble-chiseled AS base
WORKDIR /app
EXPOSE 8085
EXPOSE 8086

FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine3.23 AS build
WORKDIR /src
COPY src/Api/Api.csproj .
RUN dotnet restore Api.csproj
WORKDIR /
COPY . ./src
RUN dotnet build ./src/Api.csproj -c Release -o /app/build --no-restore 

ENV NODE_ENV=production
FROM node:22.22.2-bookworm-slim AS clientbuild
WORKDIR /app/client
COPY src/Api/ClientApp/ /app/client
RUN npm ci
RUN npm run build

FROM build AS publish
RUN dotnet publish ./src/Api.csproj -c Release  -o /app/publish --no-restore \
&& rm -rf /app/publish/src
COPY --from=clientbuild /app/client/dist /app/publish/wwwroot

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Api.dll"]