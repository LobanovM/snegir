using Snegir.Core.Entities;
using Snegir.Core.Repositories;

namespace Snegir.Core.Services
{
    public class ContentService
    {
        #region Fields

        private readonly IContentRepository _repository;

        #endregion

        #region Constructors

        public ContentService(IContentRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public

        public Content GetNextContent()
        {
            return _repository.GetAll().FirstOrDefault();
        }

        #endregion
    }
}
