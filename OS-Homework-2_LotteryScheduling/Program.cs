// Operating Systems Homework 2: Lottery Scheduling Algorithm
// Aaron Barrett

using System;
using System.Collections.Generic;
using System.Linq;

namespace OS_Homework_2_LotteryScheduling
{
    public class Process
    {
        public int ID { get; set; } // Unique Identifier
        public List<int> Tickets { get; set; } // The list of tickets assigned to the process

        public Process(int id) // initialize the process
        {
            ID = id;
            Tickets = new List<int>();
        }

        public void AssignTickets(List<int> tickets) // Give the process tickets
        {
            Tickets.AddRange(tickets);
        }
    }

    public class Scheduler
    {
        private List<Process> processes;
        private Random random;
        private int ticketCounter;

        public Scheduler()
        {
            processes = new List<Process>();
            random = new Random();
            ticketCounter = 1;
        }

        public void AddProcess(Process process)
        {
            processes.Add(process);
        }

        public void AllocateTickets(int ticketsPerProcess)
        {
            // Allocate the same number of tickets to each process in the process list
            foreach (Process process in processes)
            {
                List<int> tickets = Enumerable.Range(ticketCounter, ticketsPerProcess).ToList(); // Generates a range of tickets
                process.AssignTickets(tickets); // Assigns the tickets to the process
                ticketCounter += ticketsPerProcess;
            }
        }

        public Process SelectNextProcess()
        {
            int totalTickets = processes.Sum(x => x.Tickets.Count); // Count the number of tickets for all of the processes
            int winningTicket = random.Next(1, totalTickets+1); // Pick the next random ticket number

            foreach(Process process in processes)
            {
                // Check if the process has the winning ticket
                if(process.Tickets.Contains(winningTicket))
                {
                    return process;
                }
            }

            return null; // Only occurs if somehow the tickets aren't correctly distributed. Just makes the function happy to always have a return.
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the scheduler
            Scheduler s = new Scheduler();

            // Make some processes
            s.AddProcess(new Process(1));
            s.AddProcess(new Process(2));
            s.AddProcess(new Process(3));
            s.AddProcess(new Process(4));

            // Give the processes tickets
            s.AllocateTickets(20);

            Process winningProcess = s.SelectNextProcess();
            Console.WriteLine($"Process {winningProcess.ID} wins the lottery!");
        }
    }
}
