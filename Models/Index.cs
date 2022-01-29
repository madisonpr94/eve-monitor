using Eve.Repositories;

namespace Eve.Models
{
    public class Index
    {
        private readonly IMeasurementRepository _repository;

        public Index(IMeasurementRepository repository)
        {
            _repository = repository;
        }

        public int Count {
            get {
                return _repository.Count;
            }
        }
    }
}