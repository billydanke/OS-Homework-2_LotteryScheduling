# OS-Homework-2_LotteryScheduling

## Functionality
This program implements a lottery scheduling algorithm for simulated processes that could hypotethically be in an operating system.
Each process has an ID and a list of lottery tickets assigned to it, and a scheduler stores all of the active processes in a list.
From there, the scheduler can select randomly from the pool of lottery tickets and pick a winning ticket. Then, the program will
find the process that contained the winning ticket, and that becomes the winning process.

## Instructions for Execution
To run this project, you will need to have .NET 8 installed on your system. This can be downloaded through the Visual Studio Installer,
and you may already have it installed depending on your VS installation. Then, you can open the .sln file to open the project in Visual Studio,
and run it directly from VS, very similar to a C++ project. All source code is in 'Program.cs'.