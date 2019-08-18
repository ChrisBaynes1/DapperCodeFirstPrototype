using CallingApp.Data.Factories;
using CallingApp.Data.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using Translator.Core.Constants;
using Translator.Core.Factories;
using Translator.Core.Repositories;
using Translator.Core.Services;
using Translator.MySql;
using Translator.MySql.Repositories;
using Translator.MySql.Templates;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Translator.Test
{
    public class UnityConfig
    {
        public static IUnityContainer Container => RegisterTypes(new UnityContainer());

        public static IUnityContainer RegisterTypes(IUnityContainer container)
        {
            container.RegisterSingleton<IQueryTemplate, InsertTemplate>(QueryTemplateOption.Insert.ToString());
            container.RegisterSingleton<IQueryTemplate, UpdateTemplate>(QueryTemplateOption.Update.ToString());
            container.RegisterSingleton<IQueryTemplate, DeleteTemplate>(QueryTemplateOption.Delete.ToString());
            container.RegisterSingleton<IQueryTemplate, InitTableTemplate>(QueryTemplateOption.TableInit.ToString());
            container.RegisterSingleton<IQueryTemplate, ReplaceTemplate>(QueryTemplateOption.Replace.ToString());
            container.RegisterSingleton<IQueryTemplate, InsertIgnoreTemplate>(QueryTemplateOption.InsertIgnore.ToString());
            container.RegisterSingleton<IQueryTemplate, FindSingleTemplate>(QueryTemplateOption.FindSingle.ToString());
            container.RegisterSingleton<IQueryFactory, QueryFactory>();
            container.RegisterSingleton<IFieldTranslatorService, FieldTranslatorService>();

            const string connectionString = "server=127.0.0.1;user id=root;database=testmigrate;port=3306";
            container.RegisterType<MySqlConnection>(new InjectionConstructor(connectionString));
            container.RegisterType<IDbConnection, MySqlConnection>(lifetimeManager: new TransientLifetimeManager());

            var repositories =  AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(Repository<>).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.GetType()).ToList();

            foreach (var repo in repositories)  container.RegisterSingleton(repo);

            return container;
        }
    }
}
