using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using MuseumManagement.Application.Interfaces;
using MuseumManagement.Domain.Settings;
using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MuseumManagement.Infrastructure.FileManager.Services
{
    public class FileManagerService(IWebHostEnvironment webHostEnvironment) : IFileManagerService
    {

		public bool Delete(string fileUrl)
        {
			string existingPath = Path.Combine(webHostEnvironment.WebRootPath, fileUrl);
			if (File.Exists(existingPath))
			{
				File.Delete(existingPath);
				return true;
			}

			return false;
        }

        public async Task<string> Upload(IFormFile file, string fileName, string folderPath,string existingRelativePath = null)
        {
			if (!string.IsNullOrEmpty(existingRelativePath))
			{
				string existingPath = Path.Combine(webHostEnvironment.WebRootPath, existingRelativePath);
				if (File.Exists(existingPath))
				{
					File.Delete(existingPath);
				}
			}

			string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, folderPath);
			string uniqueFileName = $"{fileName}_{Path.GetRandomFileName()}{Path.GetExtension(file.FileName)}";
			string filePath = Path.Combine(uploadsFolder, uniqueFileName);

			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				await file.CopyToAsync(stream);
			}

			// Get the relative path from the web root
			string relativePath = Path.Combine(folderPath, uniqueFileName);

			return relativePath;
		}

    }
}