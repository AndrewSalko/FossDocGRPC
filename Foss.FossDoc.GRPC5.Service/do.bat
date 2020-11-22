@cls

cd "bin\Debug\net5.0\"

set ASPNETCORE_ENVIRONMENT=Development
REM set ASPNETCORE_URLS=http://localhost:5000

Foss.FossDoc.GRPC5.Service.exe  --urls http://localhost:5000

@pause