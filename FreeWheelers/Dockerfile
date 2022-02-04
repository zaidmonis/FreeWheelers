FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /FreeWheelers

COPY *.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet build "FreeWheelers.csproj" -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 80
COPY --from=build-env /out .
ENTRYPOINT ["dotnet", "FreeWheelers.dll"]