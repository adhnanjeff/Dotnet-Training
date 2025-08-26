using Hostel.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Hostel.MVC.Controllers
{
    public class StudentViewController : Controller
    {
        private readonly HttpClient _httpClient;

        public StudentViewController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("HostelAPI");
        }

        // GET: StudentView
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Student");
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<StudentViewModel>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var students = JsonConvert.DeserializeObject<List<StudentViewModel>>(json);

            return View(students);
        }

        // GET: StudentView/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"Student/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var student = JsonConvert.DeserializeObject<StudentViewModel>(json);

            return View(student);
        }

        // GET: StudentView/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"Student/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var student = JsonConvert.DeserializeObject<StudentViewModel>(json);

            return View(student);
        }

        // POST: StudentView/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            var json = JsonConvert.SerializeObject(student);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"Student/{student.Id}", content);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to update student.");
                return View(student);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: StudentView/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"Student/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            var json = await response.Content.ReadAsStringAsync();
            var student = JsonConvert.DeserializeObject<StudentViewModel>(json);

            return View(student);
        }

        // POST: StudentView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"Student/{id}");

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to delete student.");
                return RedirectToAction(nameof(Delete), new { id });
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
