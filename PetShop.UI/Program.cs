using System;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data.Repositories;

namespace PetShop.ConsoleApp
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            serviceCollection.AddScoped<IFakeDB, FakeDB>();  // NEW

            // Build provider
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            var fakeDB = serviceProvider.GetRequiredService<IFakeDB>();

            //Initialise and Start
            fakeDB.InitData();
            printer.StartUI();
        }
        #endregion
    }
}
