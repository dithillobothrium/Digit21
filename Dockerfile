# https://hub.docker.com/_/microsoft-dotnet-core
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Digit21RestAPi/*.csproj ./Digit21RestAPi/
COPY Common/*.csproj ./Common/
COPY Parser/*.csproj ./Parser/
COPY Tests/*.csproj ./Tests/
RUN dotnet restore

# copy everything else and build app
COPY Digit21RestAPi/. ./Digit21RestAPi/
COPY Common/. ./Common/
COPY Parser/. ./Parser/
COPY Tests/. ./Tests/
WORKDIR /source/Digit21RestAPi
# EXPOSE 5000
# RUN dotnet run
ENTRYPOINT ["dotnet", "run"]

# final stage/image
# FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
# WORKDIR /app
# COPY --from=build /app ./
# ENTRYPOINT ["dotnet", "aspnetapp.dll"]
