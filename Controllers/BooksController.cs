﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BookStore.Services.Exeptions;
using BookStore.Models.ViewModels;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _service;
        private readonly GenreService _genreService;

        public BooksController(BookService service, GenreService genreService)
        {
            _service = service;
            _genreService = genreService;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _service.FindAllAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _service.FindByIdAsync(id.Value);
            if (obj is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            List<Genre> genres = await _genreService.FindAllAsync();

            BookFormViewModel viewModel = new BookFormViewModel { Genres = genres };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = await _genreService.FindAllAsync();
                return View(viewModel);
            }

            viewModel.Book.Genres = new List<Genre>();

            foreach (int genreId in viewModel.SelectedGenresIds)
            {
                Genre genre = await _genreService.FindByIdAsync(genreId);
                if (genre is not null)
                {
                    viewModel.Book.Genres.Add(genre);
                }
            }
            await _service.InsertAsync(viewModel.Book);

            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _service.FindByIdAsync(id.Value);
            if (obj is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Genre> genres = await _genreService.FindAllAsync();
            BookFormViewModel viewModel = new BookFormViewModel { Book = obj, Genres = genres };

            return View(viewModel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (id != viewModel.Book.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id's não condizentes" });
            }

            try
            {
                await _service.UpdateAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _service.FindByIdAsync(id.Value);
            if (obj is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }


        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        // GET Genres/Error
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
