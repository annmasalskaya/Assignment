using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using StateStreet.Parser.Services.Domain;

namespace StateStreet.Parser.Web.Pages
{
    public partial class Index : ComponentBase
    {
        private readonly ITransformationService _transformationService;
        public Index(ITransformationService transformationService)
        {
            _transformationService = transformationService ?? throw new ArgumentNullException(nameof(transformationService));
        }

        private readonly long _maxFileSize = 1024 * 15; // TODO: add values to configuration
        private int _maxAllowedFiles = 3;

        private async Task LoadFile(InputFileChangeEventArgs e)
        {
            foreach (var file in e.GetMultipleFiles(_maxAllowedFiles))
            {
                try
                {
                    await using MemoryStream memoryStream = new MemoryStream();
                    await e.File.OpenReadStream(_maxFileSize).CopyToAsync(memoryStream);

                    using var reader = new StreamReader(memoryStream); // TODO: encoding
                    var fileAsString = await reader.ReadToEndAsync();

                    fileAsString.Split('\n').Select(s => s.Split(';'));

                    // todo: add validation to obtained string records
                }
                catch (Exception ex)
                {
                    //TODO: logging
                }
            }
        }
    }
}
