using WorkerServiceExample.Data.Entities;
using WorkerServiceExample.Data.Repository;

namespace WorkerServiceExample.Infra
{
    public class ItemService
    {
        private readonly ItemRepository _itemRepository;

        public ItemService(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _itemRepository.GetAll();
        }
        public IEnumerable<Item> GetActiveItems()
        {
            return _itemRepository.GetActiveItems();
        }
        public Item GetItemById(Guid id)
        {
            return _itemRepository.GetById(id);
        }

        public void CreateItem(Item item)
        {
            _itemRepository.Insert(item);
        }

        public void CreateItems(IEnumerable<Item> items)
        {
            _itemRepository.InsertRange(items);
        }

        public void UpdateItem(Item item)
        {
            _itemRepository.Update(item);
        }

        public void DeleteItem(Guid id)
        {
            var item = _itemRepository.GetById(id);
            if (item != null)
            {
                _itemRepository.Delete(item);
            }
        }
        public IEnumerable<Item> SearchItemsByName(string name)
        {
            return _itemRepository.GetItemsByName(name);
        }
    }
}
