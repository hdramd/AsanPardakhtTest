using AsanPardakhtTest.Client.Interfaces;
using AsanPardakhtTest.Client.Models;
using FluentScheduler;
using Refit;
using System.Runtime;

JobManager.Initialize();

JobManager.AddJob(
    () => Console.WriteLine("1 seq just passed."),
    s => s.ToRunEvery(1).Seconds()
);

var addressApi = RestService.For<IAddressApi>("http://localhost:5000/api");

if (addressApi == null)
    Console.Error.WriteLine("Failed to load address api!");

try
{
    var result = await addressApi.GetByProvianceAsync(new GetAddressesByProvianceQuery
    {
        Proviance = "Tehran"
    });
}
catch (Exception ex)
{
    Console.Error.WriteLine($"ssss: {ex.Message}");
    throw;
}

    Console.ReadLine();