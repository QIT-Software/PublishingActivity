using System.Collections.Generic;
using System.IO;
using PublishingActivity.BLL.DTO;
using PublishingActivity.BLL.Infrastructure;

namespace PublishingActivity.BLL.Interfaces
{
    public interface IPublicationService
    {
        IEnumerable<PublicationDTO> GetAllPublication(string proffesorId);

        PublicationDTO GetPublicationById(int id);

        OperationDetails AddPublication(PublicationDTO publication, string proffesorId);

        OperationDetails EditPublication(PublicationDTO publication);

        OperationDetails SoftDeletePublication(int publicationId);

        Dictionary<int, int> AllPublicationsByYears(string proffesorId);

        Stream ToCSV(string proffesorId);
    }
}
