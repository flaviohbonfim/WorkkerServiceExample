using WorkerServiceExample.Data.Entities;
using WorkerServiceExample.Infra;

namespace WorkerServiceExample.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // Exemplo de inserção de uma lista de itens
                // var itemsToAdd = new List<Item>
                // {
                //     new Item { Name = "Item 1" },
                //     new Item { Name = "Item 2" },
                //     new Item { Name = "Item 3" },
                //     new Item { Name = "Item 4" },
                //     new Item { Name = "Item 5" },
                //     new Item { Name = "Item 6" },
                //     new Item { Name = "Item 7" },
                //     new Item { Name = "Item 8" },
                //     new Item { Name = "Item 9" },
                //     new Item { Name = "Item 10" }
                //     // Adicione mais itens conforme necessário.
                // };
                // using (var scope = _serviceProvider.CreateScope())
                // {
                //     var itemService = scope.ServiceProvider.GetRequiredService<ItemService>();
                //     itemService.CreateItems(itemsToAdd);

                // }

                // Exemplo de leitura de todos os itens
                // using (var scope = _serviceProvider.CreateScope())
                // {
                //     var itemService = scope.ServiceProvider.GetRequiredService<ItemService>();
                //     var allItems = itemService.GetActiveItems();
                //     foreach (var item in allItems)
                //     {
                //         _logger.LogInformation($"Item: Id={item.Id}, Name={item.Name}, CreatedAt={item.CreatedAt}");
                //     }
                // }
                // using (var scope = _serviceProvider.CreateScope())
                // {
                //     var itemService = scope.ServiceProvider.GetRequiredService<ItemService>();

                //     // Busque o item que deseja atualizar pelo seu ID (por exemplo, ID = 1).
                //     var itemToUpdate = itemService.GetItemById(Guid.Parse("28619663-10bf-4bf0-bd29-648a41bf95e3"));

                //     if (itemToUpdate != null)
                //     {
                //         // Faça as alterações desejadas no item.
                //         itemToUpdate.Name = "Novo Nome"; // Por exemplo, atualize o nome.

                //         // Chame o método para atualizar o item no banco de dados.
                //         itemService.UpdateItem(itemToUpdate);
                //     }
                // }
                // using (var scope = _serviceProvider.CreateScope())
                // {
                //     var itemService = scope.ServiceProvider.GetRequiredService<ItemService>();

                //     // Busque o item que deseja excluir pelo seu ID (por exemplo, ID = 1).
                //     var itemToDelete = itemService.GetItemById(Guid.Parse("28619663-10bf-4bf0-bd29-648a41bf95e3"));
                //     if (itemToDelete != null)
                //     {
                //         // Chame o método para excluir o item do banco de dados.
                //         itemService.DeleteItem(Guid.Parse("28619663-10bf-4bf0-bd29-648a41bf95e3"));
                //     }
                // }
                // using (var scope = _serviceProvider.CreateScope())
                // {
                //     var itemService = scope.ServiceProvider.GetRequiredService<ItemService>();
                //     var allItems = itemService.SearchItemsByName("Item 1");
                //     foreach (var item in allItems)
                //     {
                //         _logger.LogInformation($"Item: Id={item.Id}, Name={item.Name}, CreatedAt={item.CreatedAt}");
                //     }
                // }


                // Exemplo de inserção de uma lista de itens
                var itemsToAdd = new List<Test>
                {
                    new Test { Number = 1 },
                    new Test { Number = 2 },
                    new Test { Number = 3 },
                    // Adicione mais itens conforme necessário.
                };
                using (var scope = _serviceProvider.CreateScope())
                {
                    var testService = scope.ServiceProvider.GetRequiredService<TestService>();
                    testService.CreateItems(itemsToAdd);

                }
                // Exemplo de leitura de todos os itens
                using (var scope = _serviceProvider.CreateScope())
                {
                    var testService = scope.ServiceProvider.GetRequiredService<TestService>();
                    var allItems = testService.GetActiveItems();
                    foreach (var item in allItems)
                    {
                        _logger.LogInformation($"Test: Id={item.Id}, Number={item.Number}, CreatedAt={item.CreatedAt}");
                    }
                }
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
