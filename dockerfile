# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:latest as dev
RUN mkdir /work/
WORKDIR /work
COPY ./iit10/iit10.csproj /work/iit10.csproj
RUN dotnet restore 
#iit10.csproj

COPY ./iit10/ /work
RUN mkdir /out/
RUN cd /work/ 
RUN dotnet publish --output /out/ --configuration Release


# Stage 2: Create the production image
FROM mcr.microsoft.com/dotnet/aspnet:latest as prod
RUN mkdir /app/
WORKDIR /app
COPY --from=dev /out/ /app/
ENTRYPOINT ["dotnet", "iit10.dll"]
