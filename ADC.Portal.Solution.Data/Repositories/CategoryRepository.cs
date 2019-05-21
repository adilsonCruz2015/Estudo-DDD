using ADC.Portal.Solution.Data.Repositories.Common;
using ADC.Portal.Solution.Domain.Command.CategoryCmd;
using ADC.Portal.Solution.Domain.Interfaces.Repositories;
using ADC.Portal.Solution.Domain.ObjectValue;
using ADC.Portal.Solution.Notification.Validation;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ADC.Portal.Solution.Data.Repositories
{
    public class CategoryRepository :
        RepositoryNHibernate<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(IConnection connection)
            :base(connection)  {  }

        public override void Update(Category entity)
        {
            NameSingle(entity);
            if(IsValid())
                base.Update(entity);
        }

        public override void Add(Category entity)
        {
            NameSingle(entity);
            if(IsValid())
                base.Add(entity);
        }

        public IEnumerable<Category> Filter(FilterCmd command)
        {
            IList<Category> results = new List<Category>();
            StringBuilder sql = new StringBuilder();
            StringBuilder sqlFilter = new StringBuilder();
            StringBuilder sqlKeyWord = new StringBuilder();
            IList<string> textKeyWord = command.DismemberKeyWord();

            sql.Append("SELECT Cat FROM Category as Cat");

            if (command.Category.Count > 0)
                sqlFilter.Append(" AND Cat.Id IN (:CategoryId) ");

            if (command.Status.Count > 0)
                sqlFilter.Append(" AND Cat.Status IN (:Status) ");

            if (!string.IsNullOrWhiteSpace(command.PerName))
                sqlFilter.Append(" AND Cat.Name = : PerName ");

            if(!Equals(textKeyWord, null) && textKeyWord.Count > 0)
            {
                sqlFilter.Append(" AND ( ");
                for(int i =0; i < textKeyWord.Count(); i++)
                    sqlKeyWord.Append(string.Format(" OR CollateLatinGeneral(Cat.Name) LIKE :texto{0} ", i));

                sqlFilter.Append(Regex.Replace(sqlKeyWord.ToString(), @"^ OR ", ""));
                sqlFilter.Append(" ) ");
            }

            sql.Append(Regex.Replace(sqlFilter.ToString(), @"^ And ", " WHERE "));

            var query = Connection.Session.CreateQuery(sql.ToString());

            query.SetMaxResults(command.Maximum);
            query.SetFirstResult((command.Page -1) * command.Maximum);
            query.SetResultTransformer(new DistinctRootEntityResultTransformer());

            if (command.Category.Count > 0)
                query.SetParameterList("CategoryId", command.Category);

            if (command.Status.Count > 0)
                query.SetParameterList("Status", command.Status);

            if (!string.IsNullOrEmpty(command.PerName))
                query.SetString("PerName", command.PerName);

            if (!Equals(textKeyWord, null) && textKeyWord.Count > 0)
            {
                for (int i = 0; i < textKeyWord.Count(); i++)
                    query.SetString(string.Format("texto{0}", i), string.Format("%{0}%", textKeyWord[i]));
            }

                results = query.List<Category>();

            if (Equals(results, null) || results.Count.Equals(0))
                Notification.AddNotification("Registro não encontrado!", TypeOfMessage.Error);

            return results;
        }

        public Category GetByName(string name)
        {
            Category result = null;

            result = Connection.Session.QueryOver<Category>()
                .WhereRestrictionOn(x => x.Name)
                .IsInsensitiveLike(name)
                .SingleOrDefault();

            if (Equals(result, null))
                Notification.AddNotification("Registro não encontrado", nameof(Category.Name), (object)name, TypeOfMessage.Attention);

            return result;
        }

        public Category NameSingle(Category category)
        {
            Notification.Clear();
            Category result = null;

            if(!string.IsNullOrEmpty(category?.Name))
            {
                result = Connection.Session.QueryOver<Category>()
                    .Where(x => x.Name.Equals(category.Name) &&
                                !x.Id.Equals(category.Id)).Take(1).List().FirstOrDefault();

                if (object.Equals(result, null))
                    Notification.AddNotification(string.Format("{0} não é único", nameof(category.Name)), nameof(category.Name), (object)category.Name, TypeOfMessage.Error);
            }

            return result;
        }
    }
}
