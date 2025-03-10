# MinimalApiGen

**MinimalApiGen** is a .NET 9 library that leverages Roslyn incremental generators to create minimal API routes and their associated services using a Fluent syntax.
It simplifies the process of setting up API routes, business logic and mappings, aiming to make it quicker to develop and maintain minimal RESTful API's.

The generation is split into two parts, Query (GETs) and Command (POST, PUT, DELETE).

## Features

**Fluent Syntax**: Define API routes and services in a readable and maintainable manner.

**Roslyn Incremental Generators**: Automate the creation of minimal APIs at compile-time for better performance and scalability.

**Customizable and Extensible**: Configure namespaces, business logic, services, and response mappings to fit your needs.

## Installation

Add the following NuGet packages to your .NET project:

```
Install-Package MinimalApiGen.Framework
Install-Package MinimalApiGen.Generators
```
## Usage

- Please see the various documents located in the doc folder for details on each Fluent command (WIP).
- Please see the QuickStartApi sample.

## Notes

Please note, this is a work in progress with the following to be added:

- Support for GET by id, POST, PUT, DELETE HTTP methods.
- Additional updates to include all required features MinimalApiGen.Framework needs into one extension method.

## License

MinimalApiGen is licensed under the GNU General Public License v3.0.

## Contact

For support or inquiries, reach out at hello@cognas.co.uk.