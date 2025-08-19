using Hostel.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Hostel.MVC.Controllers
{
    public class RoomViewController : Controller
    {
        private readonly HttpClient _httpClient;

        public RoomViewController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("HostelAPI");
        }
        // GET: /RoomView/
        public async Task<IActionResult> Index()
        {
            var rooms = await _httpClient.GetFromJsonAsync<List<RoomViewModel>>("api/Room");

            if (rooms == null || !rooms.Any())
            {
                ViewBag.Message = "No bugs found!";
            }

            return View(rooms);
        }

        // GET: /RoomView/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"api/Room/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var room = JsonSerializer.Deserialize<RoomViewModel>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return View(room);
        }
    }
}
