using InventoryBlazor.Models;
using System.Net.Http.Json;

public class OrderService
{
    private readonly HttpClient _httpClient;

    public OrderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<Order>>("api/order");
            return response;
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error fetching orders : {ex.Message}");
            return new List<Order>();
        }
    }

    public async Task<Order> GetOrderByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Order>($"api/order/{id}");

    }

    public async Task AddOrderAsync(Order order)
    {
        await _httpClient.PostAsJsonAsync("api/order", order);
    }

    public async Task UpdateOrderAsync(Order order)
    {
        await _httpClient.PutAsJsonAsync($"api/order/{order.Id}", order);
    }

    public async Task DeleteOrderAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/orders/{id}");
    }
}
