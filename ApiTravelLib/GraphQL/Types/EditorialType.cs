using Core.Models;
using GraphQL.Types;
using ApiTravelLib.Dtos;

namespace ApiTravelLib.GraphQL.Types
{
    public class EditorialType : ObjectGraphType<EditorialDto>
    {
        public EditorialType()
        {
            Field(x => x.id);
            Field(x => x.Nombre).Description("Nombre de la sede");
            Field(x => x.Sede);
        }
    }
}
