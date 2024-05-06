using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Interfaces
{
    public interface IFileManagerService
    {
      Task<string> Upload(IFormFile file, string fileName, string folderPath, string existingRelativePath = null);
	  bool Delete(string fileUrl);
    }

}
