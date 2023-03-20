using System;
using System.Threading.Tasks;
public class ThreadExample
{

    public static void ThreadProc()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("ThreadProc: {0}", i);

            Thread.Sleep(0);
        }
    }

    public static void Main()
    {
        Console.WriteLine("Main thread: Start a second thread.");
        Thread t = new Thread(new ThreadStart(ThreadProc));
        t.Start();


        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("Main thread: Do some work.");
            Thread.Sleep(0);
        }

        Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
        t.Join();
        Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
        Console.ReadLine();
    }
}

public class Program
    {
        static async Task Main(string[] args)
        {
        Task<int> result1 = LongProcess1();
        Task<int> result2 = LongProcess2();
       
        Console.WriteLine("After two long processes.");
        int val = await result1; 
        DisplayResult(val);
        val = await result2; 
        DisplayResult(val);
        Console.ReadKey();
    }

    static async Task<int> LongProcess1()
    {
        Console.WriteLine("LongProcess 1 Started");
        await Task.Delay(4000); 
        Console.WriteLine("LongProcess 1 Completed");
        return 10;
    }

    static async Task<int> LongProcess2()
    {
        Console.WriteLine("LongProcess 2 Started");
        await Task.Delay(4000); 
        Console.WriteLine("LongProcess 2 Completed");
        return 20;
    }

    static void DisplayResult(int val)
    {
        Console.WriteLine(val);
    }
}