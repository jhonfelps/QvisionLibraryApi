using Core.Models;
using GraphQL.Types;
using Infraestructure.Data;
using ApiTravelLib.Dtos;

namespace ApiTravelLib.GraphQL.Types
{
    public class LibroType : ObjectGraphType<LibroDto>
    {
        public LibroType()
        {
            Field(x => x.Isbn, type: typeof(IdGraphType)).Description("Id property from the owner object.");
            Field(x => x.Titulo).Description("Name property from the owner object.");
            Field(x => x.Sinopsis).Description("Address property from the owner object.");
            Field(x => x.N_paginas).Description("Name property from the owner object.");
        }
    }
}
