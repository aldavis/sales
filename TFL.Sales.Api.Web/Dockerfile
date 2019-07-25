#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["TFL.Sales.Api.Web/TFL.Sales.Api.Web.csproj", "TFL.Sales.Api.Web/"]
COPY ["TFL.Sales.Application/TFL.Sales.Application.csproj", "TFL.Sales.Application/"]
COPY ["TFL.Sales.Domain/TFL.Sales.Domain.csproj", "TFL.Sales.Domain/"]
RUN dotnet restore "TFL.Sales.Api.Web/TFL.Sales.Api.Web.csproj"
COPY . .
WORKDIR "/src/TFL.Sales.Api.Web"
RUN dotnet build "TFL.Sales.Api.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TFL.Sales.Api.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TFL.Sales.Api.Web.dll"]