using AWSDotNetWebAdvert.SearchApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;

namespace AWSDotNetWebAdvert.SearchApi.Extensions {
    public static class AddNestConfigurationExtension
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration) {
            var url = configuration.GetSection("ES").GetValue<string>("url");
            var username = configuration.GetSection("ES").GetValue<string>("username");
            var password = configuration.GetSection("ES").GetValue<string>("password");


            var connectionSettings = new ConnectionSettings(new Uri(url))
                .BasicAuthentication(username, password)
                .DefaultIndex("adverts")
                .DefaultTypeName("advert")
                .DefaultMappingFor<AdvertType>(advert => advert.IdProperty(p => p.Id));

            var client = new ElasticClient(connectionSettings);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
