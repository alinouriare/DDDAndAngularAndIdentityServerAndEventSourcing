using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Application;
using Domain.Entities;
using Domain.Infrastructure.Storages;
using WebMVC.Models.File;
using Microsoft.AspNetCore.Mvc;
using Application.Common;
using Application.Common.Queries;
using Application.Common.Commands;

namespace WebMVC.Controllers
{
    public class FileController : Controller
    {
        private readonly Dispatcher _dispatcher;
        private readonly IFileStorageManager _fileManager;

        public FileController(Dispatcher dispatcher, IFileStorageManager fileManager)
        {
            _dispatcher = dispatcher;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            return View(_dispatcher.Dispatch(new GetEntititesQuery<FileEntry>()));
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(UploadFile model)
        {
            var fileEntry = new FileEntry
            {
                Name = model.Name,
                Description = model.Description,
                Size = model.FormFile.Length,
                UploadedTime = DateTime.Now,
                FileName = model.FormFile.FileName,
            };

            _dispatcher.Dispatch(new AddOrUpdateEntityCommand<FileEntry>(fileEntry));

            using (var stream = new MemoryStream())
            {
                await model.FormFile.CopyToAsync(stream);
                _fileManager.Create(fileEntry, stream);
            }

            _dispatcher.Dispatch(new AddOrUpdateEntityCommand<FileEntry>(fileEntry));

            return View();
        }

        public IActionResult Download(Guid id)
        {
            var fileEntry = _dispatcher.Dispatch(new GetEntityByIdQuery<FileEntry> { Id = id });
            var content = _fileManager.Read(fileEntry);
            return File(content, MediaTypeNames.Application.Octet, WebUtility.HtmlEncode(fileEntry.FileName));
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var fileEntry = _dispatcher.Dispatch(new GetEntityByIdQuery<FileEntry> { Id = id });
            return View(fileEntry);
        }

        [HttpPost]
        public IActionResult Delete(FileEntry model)
        {
            var fileEntry = _dispatcher.Dispatch(new GetEntityByIdQuery<FileEntry> { Id = model.id });

            _dispatcher.Dispatch(new DeleteEntityCommand<FileEntry> { Entity = fileEntry });
            _fileManager.Delete(fileEntry);

            return RedirectToAction(nameof(Index));
        }
    }
}