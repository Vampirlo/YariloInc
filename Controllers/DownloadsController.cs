using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace YariloInc.Controllers
{
    public class DownloadsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private string GetContentType(string filePath)
        {
            // Создаем провайдер контента файла 
            var provider = new FileExtensionContentTypeProvider();
            // Получаем тип MIME (ContentType) файла на основе его расширения
            if (!provider.TryGetContentType(filePath, out string contentType))
            {
                // Если тип MIME не удалось определить, устанавливаем "application/octet-stream"
                contentType = "application/octet-stream";
            }
            return contentType;
        }

        public IActionResult GetFileArmaAC()
        {
            // Формируем путь к файлу AC.pbo
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "AC.pbo");

            // Создаем память в виде потока данных (MemoryStream)
            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                // Копируем содержимое файла в поток памяти (MemoryStream)
                stream.CopyTo(memory);
            }
            // Устанавливаем позицию потока памяти в начало, так как мы не будет что-либо в поток записывать, нужно считывать данные из потоке.
            memory.Position = 0;

            // Имя файла, которое будет показано при скачивании
            var fileName = "AC.pbo";
            // Возвращаем объект FileResult, который предоставляет файл для скачивания
            return File(memory, GetContentType(filePath), fileName);
        }
        public IActionResult GetFileArmaDefenseOfRostov()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Defense_of_Rostov.hellanmaa.pbo");

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            var fileName = "Defense_of_Rostov.hellanmaa.pbo";
            return File(memory, GetContentType(filePath), fileName);
        }
        public IActionResult GetFileArmaFOG()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "@FOG.7z");

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            var fileName = "@FOG.7z";
            return File(memory, GetContentType(filePath), fileName);
        }

        public IActionResult GetFileHOI4InfantryDocumentationy()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Пехотная энциклопедия.docx");

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            var fileName = "Пехотная энциклопедия.docx";
            return File(memory, GetContentType(filePath), fileName);
        }
        public IActionResult GetFileHOI4NavyDocumentationy()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", "Пехотная энциклопедия.docx");

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            var fileName = "Шаблоны морских кораблей.docx";
            return File(memory, GetContentType(filePath), fileName);
        }
    }
}
