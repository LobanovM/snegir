using Snegir.Core.Entities;
using Snegir.Core.Interfaces;
using Snegir.Core.Types;

namespace Snegir.Core.Services
{
    public class ContentService
    {
        #region Fields

        private readonly IRepository<Content> _repository;

        #endregion

        #region Constructors

        public ContentService(IRepository<Content> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public

        public Content? GetFirstUnrated()
        {
            return _repository.Get(c => c.Rating == Rating.None).FirstOrDefault();
        }

        #endregion
    }
}
