using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using ApiTravelLib.GraphQL.Queries;
using System;

namespace ApiTravelLib.GraphQL.SchemaGraph
{
    public class TravelLibSchema : Schema
    {
        public TravelLibSchema(IServiceProvider provider)
        : base(provider)
        {
            Query = provider.GetRequiredService<LibroQuery>();
        }
    }
}
