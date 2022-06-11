using System.Collections.Generic;
using System.IO;
using PublishingActivity.DAL.Entities;

namespace PublishingActivity.BLL.Models
{
    public class Parser
    {
        public static Stream ToCSV(IEnumerable<Publication> publications)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            foreach (var publication in publications)
            {
                var subject = "\"" + publication.Subject + "\"";
                var locationAndDate = "\"" + publication.LocationAndDate + "\"";
                var pages = "\"" + publication.Pages + "\"";
                var coAuthors = "\"" + publication.CoAuthors + "\"";

                writer.Write(string.Join(",", subject, "Друк.", locationAndDate, pages, coAuthors) + "\n");
                writer.Flush();
            }
            
            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }
    }
}
