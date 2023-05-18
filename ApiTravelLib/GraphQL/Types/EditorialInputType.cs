
using GraphQL.Types;

namespace ApiTravelLib.GraphQL.Types
{
    public class EditorialInputType : InputObjectGraphType
    {
        public EditorialInputType()
        {
            Name = "EditorialesInput";
            Field<NonNullGraphType<StringGraphType>>("Nombre").Description = "Nombre de la Editorial";
            Field<NonNullGraphType<StringGraphType>>("Sede").Description = "Sede de la Editorial";
        }
    }
}
