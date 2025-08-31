using Ecommerce.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Ecommerce.MVC.Controllers
{
    public class UserViewController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserViewController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EcommerceAPI");
        }

        // GET: /UserView/
        public async Task<IActionResult> Index()
        {
            var users = await _httpClient.GetFromJsonAsync<List<UserViewModel>>("api/User");
            return View(users);
        }

        // GET: /UserView/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var user = await _httpClient.GetFromJsonAsync<UserViewModel>($"api/User/{id}");
            if (user == null)
                return NotFound();

            return View(user);
        }

        // GET: /UserView/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var user = await _httpClient.GetFromJsonAsync<UserViewModel>($"api/User/{id}");
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: /UserView/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _httpClient.PutAsJsonAsync($"api/User/{id}", model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound();

            ModelState.AddModelError(string.Empty, "Unable to update user.");
            return View(model);
        }

        // GET: /UserView/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _httpClient.GetFromJsonAsync<UserViewModel>($"api/User/{id}");
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: /UserView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/User/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return NotFound();

            ModelState.AddModelError(string.Empty, "Unable to delete user.");
            return RedirectToAction(nameof(Delete), new { id });
        }

        // Optional: GET and POST for Create
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await _httpClient.PostAsJsonAsync("api/User", model);
            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));

            ModelState.AddModelError(string.Empty, "Unable to create user.");
            return View(model);
        }
    }
}
