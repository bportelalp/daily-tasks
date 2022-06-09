# Daily tasks.

Este repositorio incluye desarrollos de aplicaciones de tareas de la vida diaria, con un objetivo claramente didáctico:

* Aprender a usar EF Core con el enfoque Code-First, usando migraciones, y probando a despliegue en distintos proveedores de base de datos (MSSql y PostgreSQL en principio)

* Aprender a crear una aplicación con seguridad mediante IdentityServer y JWT.

Además también se busca perfeccionar los conocimientos y la soltura en diseñar una app con la arquitectura hexagonal de Alistair Cockburn.

En el repositorio se incluirán varias aplicaciones, que beberán de otro repositorio que está insertado como submodulo.

* dotnet-components. Componentes genéricos y variados de .NET.

Todo el código del repositorio empieza en la versión .NET 6.

## ShoppingTracker

Una aplicación para realizar un seguimiento de productos y precios en supermercados.

Se intenta tener los productos en la base de datos clasificados por tipo de producto y por formato de presentación, así como cantidades y evolución de precios.