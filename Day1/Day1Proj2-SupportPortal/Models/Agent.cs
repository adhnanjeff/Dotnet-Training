using System;

namespace Day1Proj2.Models
{
    public class Agent
    {
        public int AgentId { get; set; }
        public string AgentName { get; set; }
        public string AgentRole { get; set; }

        public Agent(int id, string name, string role)
        {
            AgentId = id;
            AgentName = name;
            AgentRole = role;
        }

        public static void DisplayAgent(Agent agent)
        {
            Console.WriteLine("------ Agent Info ------");
            Console.WriteLine($"Id: {agent.AgentId}");
            Console.WriteLine($"Name: {agent.AgentName}");
            Console.WriteLine($"Role: {agent.AgentRole}");
        }
    }
}
