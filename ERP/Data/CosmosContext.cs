using Microsoft.Extensions.Configuration;
using Microsoft.Azure.Cosmos;
using System;
using ERP.Config;

namespace ERP.Data
{
    public class CosmosContext<T>
    {
        private readonly IConfiguration _configuration;
        private readonly string _databaseId = "crudDW";

        public CosmosContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Add(string containerId, T data, string Id)
        {
            try
            {
                string endpointUri = AppSettings.CosmosDbEndpointUri;
                string primaryKey = AppSettings.CosmosDdPrimaryKey;

                using (CosmosClient cosmosClient = new CosmosClient(endpointUri, primaryKey))
                {
                    Database database = cosmosClient.GetDatabase(_databaseId);
                    Container container = database.GetContainer(containerId);

                    await container.CreateItemAsync(data, new PartitionKey(Id));
                }
            }
            catch (CosmosException ex)
            {
                throw new Exception("Erro ao adicionar item ao CosmosDB", ex);
            }
        }
    }
}
