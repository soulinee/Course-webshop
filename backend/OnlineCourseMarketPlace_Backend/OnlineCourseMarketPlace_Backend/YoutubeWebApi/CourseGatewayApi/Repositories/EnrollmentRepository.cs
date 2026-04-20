using System;
using CourseGatewayApi.Options;
using CourseGatewayApi.Storage.Contracts;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace CourseGatewayApi.Repositories;

public class EnrollmentRepository( IOptions<EnrollmentRepositoryOptions> options): IEnrollmentRepository
{
    public async Task<EnrollmentStorageContract> CreateAsync(
        EnrollmentStorageContract contract)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(contract);
        Console.WriteLine("COSMOS JSON >>> " + json);

        var response = await GetContainer()
        

            .CreateItemAsync(
                contract,
               new PartitionKey(contract.id)

            );

        return response.Resource;
    }

    public async Task<List<EnrollmentStorageContract>> 
        GetByKlantIdAsync(string klantId)
    {
        var query = new QueryDefinition(
            "SELECT * FROM c WHERE c.KlantId = @id"
        ).WithParameter("@id", klantId);

        var result = new List<EnrollmentStorageContract>();
        var iterator = GetContainer()
            .GetItemQueryIterator<EnrollmentStorageContract>(query);

        while (iterator.HasMoreResults)
        {
            result.AddRange(await iterator.ReadNextAsync());
        }

        return result;
    }

   


    private Container GetContainer()
    {
        var client = new CosmosClient(
            options.Value.Connectionstring);

        return client
            .GetDatabase(options.Value.DatabaseName)
            .GetContainer(options.Value.ContainerName);
    }

}
