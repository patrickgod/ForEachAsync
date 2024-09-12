async Task<List<string>> FetchDataAsync(List<int> ids)
{
    var results = new List<string>();

    await Parallel.ForEachAsync(ids, async (id, token) =>
    {
        var result = await SimulateFetchFromDatabase(id);
        Console.WriteLine(result);
        results.Add(result);
    });

    //foreach (var id in ids)
    //{
    //    var result = await SimulateFetchFromDatabase(id);
    //    Console.WriteLine(result);
    //    results.Add(result);
    //}

    return results;
}

async Task<string> SimulateFetchFromDatabase(int id)
{
    await Task.Delay(1000);
    var result = $"Data for ID {id}";
    return result;
}

var ids = new List<int> { 1, 2, 3, 4 };
var fetchedData = await FetchDataAsync(ids);

Console.WriteLine($"Fetched Data Count: {fetchedData.Count}");
