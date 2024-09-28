using System;
using System.Diagnostics;
using System.Timers;

class Test {
  public static string name;
  public static void Main() {
    Console.WriteLine("Enter the name of the process you want to block:");
    name = Console.ReadLine();
    Console.WriteLine("Enter the interval (ms) to kill process:");
    int interval = Int32.Parse(Console.ReadLine());

    Timer t;
    t = new System.Timers.Timer();
    t.Elapsed += new ElapsedEventHandler(killTask);
    t.Interval = interval;
    t.Enabled = true;

    while (true);
  }
  private static void killTask(object source, ElapsedEventArgs args) {
    Console.WriteLine("Attempting...");
    Process[] processes = Process.GetProcesses();
    foreach (Process p in processes) {
      if (name.Equals(p.ProcessName)) {
        try {
          p.Kill();
        } catch (Exception e) {
          Console.WriteLine("Exception: {0}", e);
        }
      }
    }

  }
}
