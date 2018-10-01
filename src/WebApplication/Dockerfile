FROM microsoft/dotnet:2.1-sdk
WORKDIR /app

EXPOSE 80
EXPOSE 1433 
EXPOSE 5555 



# copy csproj and restore as distinct layers
ARG source
COPY ${source:-bin/Debug/netcoreapp2.1/publish} .


ENTRYPOINT ["dotnet", "WebApplication.dll"]