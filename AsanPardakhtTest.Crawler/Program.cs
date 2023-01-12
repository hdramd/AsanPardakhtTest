using FluentScheduler;

JobManager.Initialize();

JobManager.AddJob(
    () => Console.WriteLine("1 seq just passed."),
    s => s.ToRunEvery(1).Seconds()
);

Console.ReadLine();