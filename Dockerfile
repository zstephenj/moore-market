FROM microsoft/dotnet:2.2-sdk
WORKDIR /app

# copy csproj and restore as distinct layers
COPY ./MooreMarket/*.csproj ./
RUN dotnet restore

# copy and build everything else
COPY ./MooreMarket ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/MooreMarket.dll"]
