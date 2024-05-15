using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Moq;
using Newtonsoft.Json;

namespace DynamoDBLowLevelAPI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // mock a fake response
            Dictionary<string, AttributeValue> mockGetItemResponseItem = new Dictionary<string, AttributeValue>
            {
                { "id", new AttributeValue { S = "123" } },
                { "name", new AttributeValue { S = "John Doe" } },
                { "age", new AttributeValue { N = "30" } }
            };

            GetItemResponse mockResponse = new GetItemResponse
            {
                Item = mockGetItemResponseItem
            };

            // mock a fake dynamodb client
            Mock<IAmazonDynamoDB> mockClient = new Mock<IAmazonDynamoDB>();
            mockClient.Setup(c => c.GetItemAsync(It.IsAny<GetItemRequest>(), default))
                .ReturnsAsync(mockResponse);

            Person person = await GetPersonFromDynamoDB(mockClient.Object, "123");

            if (person == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}");
        }

        static async Task<Person> GetPersonFromDynamoDB(IAmazonDynamoDB client, string id)
        {
            Dictionary<string, AttributeValue> requestKey = new Dictionary<string, AttributeValue>
            {
                { "id", new AttributeValue { S = id } }
            };
            GetItemRequest getItemRequest = new GetItemRequest
            {
                TableName = "my-table",
                Key = requestKey
            };

            GetItemResponse getItemResponse = await client.GetItemAsync(getItemRequest);

            if (getItemResponse.Item.Count <= 0)
            {
                throw new KeyNotFoundException("Item not found.");
            }

            // return ConvertToPersonByExtractAttributeValue(getItemResponse);
            return ConvertToPersonByJsonSerializerSettings(getItemResponse);
        }

        static Person ConvertToPersonByExtractAttributeValue(GetItemResponse getItemResponse)
        {
            // Directly extract the value of AttributeValue
            return new()
            {
                Id = getItemResponse.Item["id"].S,
                Name = getItemResponse.Item["name"].S,
                Age = int.Parse(getItemResponse.Item["age"].N)
            };
        }

        static Person ConvertToPersonByJsonSerializerSettings(GetItemResponse getItemResponse)
        {
            // Use custom JsonConverter to convert AttributeValue to Person
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                Converters = { new CustomJsonConverter() }
            };
            string jsonString = JsonConvert.SerializeObject(getItemResponse.Item, jsonSerializerSettings);
            Person person = JsonConvert.DeserializeObject<Person>(jsonString, jsonSerializerSettings)
                            ?? throw new InvalidOperationException();

            return person;
        }
    }
}
