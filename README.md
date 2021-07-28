# Weelo - Clean Arquitecture

Aplicación Rest API para la administración de propiedades.

## Domain-Driven Design Patterns

### Value Object

Describe las reglas comerciales de los dominios pequeños. Objetos que son únicos por las propiedades de sus propiedades. Son inmutables.

### Domain

El paquete que contiene los `módulos de alto nivel` que describen el dominio a través de raíces agregadas, entidades y objetos de valor. Por diseño, este proyecto es `altamente abstracto` y `estable`; en otros términos, este paquete contiene una cantidad considerable de interfaces y no debería depender de bibliotecas y marcos externos. Idealmente, debería estar acoplado de manera flexible incluso con .NET Framework.

### Application

Un proyecto que contiene los casos de uso de aplicaciones que orquestan las reglas comerciales de alto nivel. Por diseño, la orquestación dependerá de abstracciones de servicios externos (por ejemplo, repositorios). El paquete expone las interfaces de límites (en otros términos, contratos o `puertos`) que utiliza la interfaz de usuario.

### Infrastructure

La capa de infraestructura es responsable de implementar los `Adaptadores` a los` Actores secundarios`. Por ejemplo, una base de datos de SQL Server es un actor secundario que se ve afectado por los casos de uso de la aplicación, toda la implementación y las dependencias necesarias para consumir SQL Server se crean en la infraestructura. Por diseño, la infraestructura depende de la capa de aplicación.

### User Interface

El punto de entrada del sistema responsable de renderizar una interfaz para interactuar con el Usuario. Hecho con controladores que reciben solicitudes HTTP y presentadores que convierten las salidas de la aplicación en ViewModels que se representan como respuestas HTTP.

## Configuración para ejecutar localmente la aplicación

Primero sera construir nuestra base de datos y crear las tablas y para esto se va a utilizar Entity Framework - Code first

Ejecuta por favor los comandos para crear la base de datos despues de haber instalado docker y haber creado el contenedor de base de datos SQL Server y el contenedor de Redis.

### Add Migration

Habilite Entity Framework Tool para agregar una migración al proyecto `Weelo.Infrastructure`.

```sh
dotnet tool update --global dotnet-ef --version 5.0.7
```

```sh
dotnet ef migrations add InitialCreate --project ./source/Weelo.Infrastructure/Weelo.Infrastructure.csproj --startup-project ./source/Weelo.API/
```

### Update Database

Genere tablas y genere la base de datos a través de Entity Framework Tool:

```sh
dotnet ef database update --project ./source/Weelo.Infrastructure/Weelo.Infrastructure.csproj --startup-project ./source/Weelo.API/
```

### Ejecución de la aplicación localmente

Weelo es una aplicación multiplataforma, puedes ejecutarla desde Mac, Windows o Unix. Para desarrollar nuevas funciones, puede utilizar Visual Studio o Visual Studio Code.

Los únicos requisitos son instalar el SDK de .NET Core más reciente y Docker.

* [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
* [Docker](https://docs.docker.com/get-docker/)


Finalmente, para ejecutarlo localmente, use :

```sh
dotnet run --project ./source/Weelo.API/Weelo.API.csproj
```

### Ejecución de las pruebas de forma local

Ejecute el siguiente comando en la carpeta raíz:

```sh
dotnet test
```

## Docker

Los siguientes son los comandos para crear los diferentes contenedores para que la aplicación corra correctamente.

### SQL Server

Para activar un SQL Server en un contenedor de docker usando la cadena de conexión `Server=localhost;User Id=sa;Password=<YourNewStrong!Passw0rd>;` ejecuta el siguiente comando:

```sh
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong!Passw0rd>" -p 1433:1433 --name sql -d --restart always mcr.microsoft.com/mssql/server:2019-latest
```

### Redis

Para activar un Redis en un contenedor docker, ejecute el siguiente comando:

```sh
docker run -p 6379:6379 --name redis -d --restart always redis
```

El siguiente es el Dockerfile para construir la imagen de docker de la aplicación

```sh
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/out .
CMD dotnet Weelo.API.dll
```

## Datos de Autenticación

username: admin
password: 123456

## Instrucciones para interactuar con la autenticación JWT

Una vez levantado el proyecto iremos a la siguiente url.

[https://localhost:5001/swagger](https://localhost:5001/swagger)

Deberas de autenticarte con los datos que estan en este documento para poder obtener el JWT Token el cual se debe de agregar como encabezado en la opcion de **Authorize** anticipado por **Bearer**

```bash
Bearer ${token}
```

![](https://miro.medium.com/max/1600/1*IrmDxmBcpvBUltIO4UQN5Q.gif)