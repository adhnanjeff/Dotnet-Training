using System;

namespace Day1Proj2.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public string RequestDescription { get; set; }
        public string Reqstatus { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public float ResolutionTime { get; private set; }
        public bool IsClosed { get; private set; }
        public Agent AssignedBy { get; set; }
        public Agent AssignedTo { get; set; }
        public Request(int id, string description, Agent agentFrom, Agent agentTo)
        {
            RequestId = id;
            RequestDescription = description;
            Reqstatus = "Not Resolved";
            CreatedOn = DateTime.Now;
            ResolutionTime = 0; // Default resolution time
            IsClosed = false;
            AssignedBy = agentFrom;
            AssignedTo = agentTo;
        }
        public void ResolveRequest()
        {
            IsClosed = true;
            Reqstatus = "Resolved";
            ResolutionTime = (float)(DateTime.Now - CreatedOn).TotalHours; // Calculate resolution time in minutes
        }

        public static void ReassignRequest(Request req, Agent agent)
        {
            if (req.IsClosed)
            {
                Console.WriteLine("Cannot reassign a closed request.");
                return;
            }
            else
            {
                req.AssignedTo = agent;
            }
        }

        public static void DisplayRequest(Request request) {
             Console.WriteLine("------ Request Info ------");
             Console.WriteLine($"RequestId: {request.RequestId}");
             Console.WriteLine($"Description: {request.RequestDescription}");
             Console.WriteLine($"Status: {request.Reqstatus}");
             Console.WriteLine($"Created On: {request.CreatedOn}");
             Console.WriteLine($"Resolution Time (in hours): {request.ResolutionTime}");
             Console.WriteLine($"Assigned By: {request.AssignedBy.AgentName}");
             Console.WriteLine($"Assigned To: {request.AssignedTo.AgentName}");
        }
    }
}