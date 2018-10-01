FROM microsoft/dotnet:2.1-sdk
WORKDIR /app
EXPOSE 5555 
EXPOSE 80
# copy csproj and restore as distinct layers
ARG source
COPY ${source:-bin/Debug/netcoreapp2.1/publish} .

ENTRYPOINT ["dotnet", "MSCheckStatus.dll"]