# --------- Backend ---------

FROM microsoft/dotnet:2.2-sdk as api
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./MooreMarket/*.csproj ./
RUN dotnet restore

# copy and build everything else
COPY ./MooreMarket ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/MooreMarket.dll"]

# --------- Frontend ---------

FROM nginx:latest as ui

# copy nginx config into container
COPY frontend/conf/nginx.conf /etc/nginx/nginx.conf

# copy the frontend assets into container
COPY frontend/dist /usr/share/nginx/html
