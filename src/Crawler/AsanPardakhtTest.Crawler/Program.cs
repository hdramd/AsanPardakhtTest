using AsanPardakhtTest.Crawler.Scheduler;
using FluentScheduler;

Console.Title = "Address Crawler";
Console.WriteLine("Crawler Runs every 10 minutes ...");

JobManager.Initialize();

JobManager.AddJob(new AddressCrawlerJob(),
    s => s.ToRunEvery(10).Minutes()
);

Console.ReadLine();