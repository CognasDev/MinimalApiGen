# MinimalApiGen

**MinimalApiGen** is a .NET 9 library that leverages Roslyn incremental generators to create minimal API routes and their associated services using a Fluent syntax.
It simplifies the process of setting up API routes, business logic and mappings, aiming to make it quicker to develop and maintain minimal RESTful API's.

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

Example: Defining a GET API Route

Here's an example of how to use MinimalApiGen to define minimal API routes and associate them with services and business logic:

```cs
[MinimalApiGen.Framework.Generation.QueryGenerator]
public class Example
{
    public Example()
    {
        ApiGeneration.Query<YourModel>()
                     .WithNamespaceOf<IYourBusinessLogic>()
                     .WithGet()
                         .WithBusinessLogic<IYourBusinessLogic>(logic => logic.GetModelsAsync)
                         .WithServices<YourService>()
                         .WithResponse<YourResponse>()
                         .WithMappingService();
    }
}
```

### Breakdown of the Example

**Define a Query:** ```ApiGeneration.Query<YourModel>()``` - This initializes a query for the YourModel type.

**Set Namespace:** ```.WithNamespaceOf<IYourBusinessLogic>()``` - Specifies the namespace for the generated API.

**Add HTTP GET Method:** ```.WithGet()``` - Adds support for the GET HTTP method.

**Attach Business Logic:** ```.WithBusinessLogic<IYourBusinessLogicV1>(logic => logic.GetModelsAsync)``` - Links the GET request to a business logic method.

**Include Required Services:** ```.WithServices<YourService>()``` - Specifies services required for the operation (parameters of the business logic method).

**Define Response Type:** ```.WithResponse<YourResponse>()``` - Maps the query to a specific response type.

**Add Mapping Service:** ```.WithMappingService()``` - Generates a service which maps models to responses.

## Notes

Please note, this is a work in progress with the following to be added:

- Support for POST, PUT, DELETE HTTP methods.
- Additional updates to include all required features the Framework needs into one extension method.

## License

MinimalApiGen is licensed under the GNU General Public License v3.0.

## Contact

For support or inquiries, reach out at hello@cognas.co.uk.