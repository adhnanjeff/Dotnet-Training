using Lms.Infrastructure.Repositories;
using Lms.Application.Services;

namespace IssueTracker.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var leaveRepo = new LeaveRepository();
            var leaveService = new LeaveService(leaveRepo);

            while (true)
            {
                Console.WriteLine("1. Apply for a leave\n" +
                                  "2. Delete a leave record\n" +
                                  "3. View All Leaves\n" +
                                  "4. Update Leave\n" +
                                  "5. Exit\n");
                Console.WriteLine("Enter your Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                     
                        Console.WriteLine("Enter the name of the employee\n");
                        string Name = Console.ReadLine();
                        Console.WriteLine("Enter the type of leave (e.g., 'casual', 'sick')\n");
                        string TypeOfLeave = Console.ReadLine();
                        leaveService.CreateLeave(Name, TypeOfLeave);
                        break;

                    case 2:
                        Console.WriteLine("Enter the Id of the Leave record to be deleted\n");
                        int LeaveToDelete = Convert.ToInt32(Console.ReadLine());
                        leaveRepo.DeleteLeave(LeaveToDelete);
                        break;

                    case 3:
                        var leaves = leaveService.GetAllLeaves();
                        if (leaves.Count == 0)
                        {
                            Console.WriteLine("No leaves found.\n");
                        }
                        else
                        {
                            foreach (var leave in leaves)
                            {
                                Console.WriteLine($"ID: {leave.Id}, Employee: {leave.NameOfEmployee}, Type: {leave.TypeOfLeave}, Status: {leave.Status}");
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the ID of the leave to approve\n");
                        int approveId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the status to update (Approved/Rejected)\n");
                        string status = Console.ReadLine();
                        leaveRepo.UpdateLeave(approveId, status);
                        Console.WriteLine($"Leave with ID {approveId} updated to {status}.\n");
                        break;

                    case 5:
                        Console.WriteLine("Exiting the application.");
                        return;

                }

            }
        }
    }
}