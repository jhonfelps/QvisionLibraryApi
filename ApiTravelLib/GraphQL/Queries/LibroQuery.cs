using ApiTravelLib.Dtos;
using ApiTravelLib.GraphQL.Types;
using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;
using System.Linq;

namespace ApiTravelLib.GraphQL.Queries
{
    public class LibroQuery : ObjectGraphType
    {
        public LibroQuery()
        {
            Field<ListGraphType<LibroType>>("libros", resolve:
                context => GetBooks());

            Field<LibroType>("libro", arguments: new QueryArguments(
            new QueryArgument<IdGraphType> { Name = "Isbn" }
            ), resolve: context =>
            {
                var id = context.GetArgument<int>("Isbn");
                return GetBooks().FirstOrDefault(x => x.Isbn == id);
            });
        }

        static List<LibroDto> GetBooks()
        {
            var books = new List<LibroDto>{
                new LibroDto {
                    Isbn = 1,
                    Titulo = "Fullstack tutorial for GraphQL",
                    Sinopsis = "Fullstack tutorial for GraphQL",
                    N_paginas = "15"
                },
                new LibroDto
                {
                    Isbn = 2,
                    Titulo = "Fullstack tutorial for GraphQL",
                    Sinopsis = "Fullstack tutorial for GraphQL",
                    N_paginas = "15"

                },
                new LibroDto
                {
                    Isbn = 3,
                    Titulo = "Fullstack tutorial for GraphQL",
                    Sinopsis = "Fullstack tutorial for GraphQL",
                    N_paginas = "15"
                }
            };

            return books;
        }


    }
}
