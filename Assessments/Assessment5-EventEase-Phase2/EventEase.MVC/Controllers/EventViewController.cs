using EventEase.Core.DTOs;
using EventEase.Core.Interfaces;
using EventEase.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventEase.MVC.Controllers
{
    public class EventViewController : Controller
    {
        private readonly IEventService _eventService;

        public EventViewController(IEventService eventService)
        {
            _eventService = eventService;
        }

        // GET: EventView
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllEventsAsync();

            var model = events.Select(e => new EventViewModel
            {
                Id = e.Id,
                Title = e.Title,
                Desc = e.Desc,
                EventDate = e.EventDate,
                Location = e.Location,
                Participants = e.Participants
            }).ToList();

            return View(model);
        }

        // GET: EventView/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var e = await _eventService.GetEventByIdAsync(id);
            if (e == null)
                return NotFound();

            var model = new EventViewModel
            {
                Id = e.Id,
                Title = e.Title,
                Desc = e.Desc,
                EventDate = e.EventDate,
                Location = e.Location,
                Participants = e.Participants
            };

            return View(model);
        }

        // GET: EventView/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventView/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new EventRequestDTO
            {
                Title = model.Title,
                Desc = model.Desc,
                EventDate = model.EventDate,
                Location = model.Location
            };

            await _eventService.AddEventAsync(dto);

            return RedirectToAction(nameof(Index));
        }

        // GET: EventView/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var e = await _eventService.GetEventByIdAsync(id);
            if (e == null)
                return NotFound();

            var model = new EventViewModel
            {
                Id = e.Id,
                Title = e.Title,
                Desc = e.Desc,
                EventDate = e.EventDate,
                Location = e.Location,
                Participants = e.Participants
            };

            return View(model);
        }

        // POST: EventView/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EventViewModel model)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            var dto = new EventRequestDTO
            {
                Title = model.Title,
                Desc = model.Desc,
                EventDate = model.EventDate,
                Location = model.Location
            };

            await _eventService.UpdateEventAsync(id, dto);

            return RedirectToAction(nameof(Index));
        }

        // GET: EventView/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var e = await _eventService.GetEventByIdAsync(id);
            if (e == null)
                return NotFound();

            var model = new EventViewModel
            {
                Id = e.Id,
                Title = e.Title,
                Desc = e.Desc,
                EventDate = e.EventDate,
                Location = e.Location,
                Participants = e.Participants
            };

            return View(model);
        }

        // POST: EventView/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eventService.DeleteEventAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
