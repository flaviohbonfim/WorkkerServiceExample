using WorkerServiceExample.Data.Entities;
using WorkerServiceExample.Data.Repository;

namespace WorkerServiceExample.Infra
{
    public class TestService
    {
        private readonly TestRepository _testRepository;

        public TestService(TestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        public IEnumerable<Test> GetAllItems()
        {
            return _testRepository.GetAll();
        }
        public IEnumerable<Test> GetActiveItems()
        {
            return _testRepository.GetActiveItems();
        }
        public Test GetTestById(Guid id)
        {
            return _testRepository.GetById(id);
        }

        public void CreateItem(Test Test)
        {
            _testRepository.Insert(Test);
        }

        public void CreateItems(IEnumerable<Test> Tests)
        {
            _testRepository.InsertRange(Tests);
        }

        public void UpdateItem(Test Test)
        {
            _testRepository.Update(Test);
        }

        public void DeleteItem(Guid id)
        {
            var Test = _testRepository.GetById(id);
            if (Test != null)
            {
                _testRepository.Delete(Test);
            }
        }
    }
}
