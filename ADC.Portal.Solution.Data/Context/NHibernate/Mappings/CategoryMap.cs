using ADC.Portal.Solution.Domain.ObjectValue;
using FluentNHibernate.Mapping;

namespace ADC.Portal.Solution.Data.Context.NHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidNative();

            Map(x => x.Name)
                .Nullable()
                .Length(Category.NAME_MAXLENGHT);

            Map(x => x.Description)
                .Nullable()
                .Length(Category.DESCRIPTION_MAXLENGHT);

            Map(x => x.Status)
                .Nullable();

            Map(x => x.CreatedIn)
                .Nullable()
                .Length(Category.DATA_MAXLENGHT);

            Map(x => x.ChangedIn)
                .Nullable()
                .Length(Category.DATA_MAXLENGHT);

        }
    }
}
