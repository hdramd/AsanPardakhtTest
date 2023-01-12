using AsanPardakhtTest.Client.Interfaces;
using AsanPardakhtTest.Client.Models;
using AsanPardakhtTest.Crawler.Persistence;
using FluentScheduler;
using Refit;

namespace AsanPardakhtTest.Crawler.Scheduler
{
    public class AddressCrawlerJob : IJob
    {
        public void Execute()
        {
            Task.Run(async () =>
            {
                await MainAsync();
            }).GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            try
            {
                IAddressApi addressApi = GenerateService();
                var addresses = await ReadAddressesFromApiAsync(addressApi);
                await SaveAddressesasync(addresses);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Crawler failed. Error => {ex.Message}");
            }
        }

        private static async Task SaveAddressesasync(List<AddressDto> addresses)
        {
            var entities = addresses.Select(x => new Entities.Address
            {
                Description = x.Description
            });
            using var context = new CrawlerAppDbContext();
            await context.Addresses
                  .AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        private static IAddressApi GenerateService()
        {
            var addressApi = RestService.For<IAddressApi>("http://localhost:5000/api");

            if (addressApi == null)
                throw new Exception("Failed to generate refit service.");

            return addressApi;
        }

        private static async Task<List<AddressDto>> ReadAddressesFromApiAsync(IAddressApi addressApi)
        {
            var apiResponse = await addressApi.GetByProvianceAsync(new GetAddressesByProvianceQuery
            {
                Proviance = "Tehran"
            });

            if (!apiResponse.IsSuccessStatusCode)
            {
                throw new Exception(apiResponse.Error?.Message);
            }

            if (!apiResponse.Content.Succeeded)
            {
                throw new Exception(apiResponse.Content?.ErrorMessage);
            }

            return apiResponse.Content.Data;
        }
    }
}
