// Services/InventoryService.cs
using InventoryBlazor.Models;
using System.Net.Http.Json;

public class InventoryService
{
    private readonly HttpClient _httpClient;

    public InventoryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    //public async Task<List<InventoryItem>> GetInventoryItemsAsync()
    //{
    //    return await _httpClient.GetFromJsonAsync<List<InventoryItem>>("api/inventory");
    //}
    public async Task<List<InventoryItem>> GetInventoryItemsAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<InventoryItem>>("api/Inventory");
            return response;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching inventory items: {ex.Message}");
            return new List<InventoryItem>();
        }
    }

    public async Task<InventoryItem> GetInventoryItemByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<InventoryItem>($"api/inventory/{id}");
    }

    public async Task AddInventoryItemAsync(InventoryItem item)
    {
        await _httpClient.PostAsJsonAsync("api/inventory", item);
    }

    public async Task UpdateInventoryItemAsync(InventoryItem item)
    {
        await _httpClient.PutAsJsonAsync($"api/inventory/{item.Id}", item);
    }

    public async Task DeleteInventoryItemAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/inventory/{id}");
    }
}
