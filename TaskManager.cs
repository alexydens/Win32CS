using System;
using System.Diagnostics;

class Test {
  public static void Main() {
    char option = ' ';
    Process[] processes;// = Process.GetProcesses();
    while (option != 'q') {
      Console.WriteLine("Please select one of the following commands:");
      Console.WriteLine("[a] - Print all processes");
      Console.WriteLine("[s] - Search for string in process name");
      Console.WriteLine("[k] - Kill process with specified ID");
      Console.WriteLine("[q] - Quit the application");
      option = Console.ReadLine()[0];
      switch (option) {
        case 'a':
          processes = Process.GetProcesses();
          foreach (Process p in processes) {
            Console.WriteLine("Process: {0}\t\tID: {1}", p.ProcessName, p.Id);
          }
          break;
        case 's':
          processes = Process.GetProcesses();
          Console.WriteLine("Enter your search query:");
          string search = Console.ReadLine();
          Console.WriteLine("Searched for: \"{0}\"", search);
          bool found_any = false;
          foreach (Process p in processes) {
            //if (search.Equals(p.ProcessName)) {
            if (p.ProcessName.Contains(search)) {
              Console.WriteLine("Process: {0}\t\tID: {1}", p.ProcessName, p.Id);
              found_any = true;
            }
          }
          if (!found_any) Console.WriteLine("Found no results for that query");
          break;
        case 'k':
          processes = Process.GetProcesses();
          Console.WriteLine("Enter the process ID");
          int id = Int32.Parse(Console.ReadLine());
          foreach (Process p in processes) {
            if (p.Id == id)
              p.Kill();
          }
          break;
        case 'q':
          Console.WriteLine("Quitting...");
          break;
        default:
          Console.WriteLine("Unrecognized option!");
          break;
      }
    }
  }
}
