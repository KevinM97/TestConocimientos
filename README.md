### Configuring the sample to use SQL Server

1. Asegúrese de que sus cadenas de conexión `appsettings.json` apunten a una instancia local de SQL Server.
2. Asegúrese de que la herramienta EF ya esté instalada. Puedes encontrar ayuda [aquí](https://docs.microsoft.com/ef/core/miscellaneous/cli/dotnet)

    ```
    dotnet tool update --global dotnet-ef
    ```

3. Abra un símbolo del sistema en la carpeta Web y ejecute los siguientes comandos:

    ```
    dotnet restore
    dotnet tool restore
    dotnet ef database update -c catalogcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj
    dotnet ef database update -c appidentitydbcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj
    ```

    Estos comandos crearán dos bases de datos separadas, una para los datos del catálogo de la tienda y la información del carrito de compras, y otra para las credenciales de usuario y los datos de identidad de la aplicación.

4. Ejecute la aplicación.

    La primera vez que ejecute la aplicación, se generarán ambas bases de datos con datos que le permitirán ver los productos en la tienda y podrá iniciar sesión con la cuenta demouser@microsoft.com .
    
    Nota: Si necesita crear migraciones, puede usar estos comandos:

    ```
    -- create migration (from Web folder CLI)
    dotnet ef migrations add InitialModel --context catalogcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj -o Data/Migrations

    dotnet ef migrations add InitialIdentityModel --context appidentitydbcontext -p ../Infrastructure/Infrastructure.csproj -s Web.csproj -o Identity/Migrations
    ```
