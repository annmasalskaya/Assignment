using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using StateStreet.Parser.Web.Constants;
using StateStreet.Parser.Web.DomainModels;
using StateStreet.Parser.Web.Models;

namespace StateStreet.Parser.Web.Pages
{
    public partial class Index : ComponentBase
    {
        private const long MaxFileSize = 3072000;

        private IEnumerable<EventModel> _eventModels = Enumerable.Empty<EventModel>();

        private async Task LoadFileAsync(InputFileChangeEventArgs loadFileEvent)
        {
            var fileAsString = await ReadFileToStringAsync(loadFileEvent);

            var fileRows = fileAsString.Split(StringConstants.NewLineNonUnixPlatform, StringSplitOptions.RemoveEmptyEntries);
            var rawEventData = new RawEventData(CreateRawEvents(fileRows));

            ValidationService.ValidateInputData(rawEventData);

            var eventData = rawEventData.RawEvents.Select(ev => new EventData(ev)).ToArray();
            ValidationService.ValidateEventData(eventData);
            
            _eventModels = eventData.Select(x => new EventModel(x));
        }


        private async Task<string> ReadFileToStringAsync(InputFileChangeEventArgs loadFileEvent)
        {
            try
            {
                await using var memoryStream = new MemoryStream();
                await loadFileEvent.File.OpenReadStream(MaxFileSize).CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin); 
                
                using var reader = new StreamReader(memoryStream, Encoding.UTF8);

                return await reader.ReadToEndAsync();
            }
            catch (Exception exception)
            {
                //Serilog requires EventId, quite dummy using
                Logger.LogError(new EventId(1, "Error"), exception, exception.Message);
                throw;
            }
        }

        private IEnumerable<string[]> CreateRawEvents(string[] rawInput)
        {
            foreach (var item in rawInput)
            {
                yield return item.Trim()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .Select(i => i.Trim()).ToArray();
            }
        }
    }
}
