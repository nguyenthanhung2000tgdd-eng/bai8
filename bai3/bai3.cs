using System;
using System;

class CompanySystem
{
    public class Member
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int CompletedTasks { get; set; }

        public Member(string id, string name, int completedTasks)
        {
            Id = id;
            Name = name;
            CompletedTasks = completedTasks;
        }

        public override string ToString()
        {
            return $"ID: {Id,-8} | Name: {Name,-20} | Completed Tasks: {CompletedTasks}";
        }
    }

    static void Main()
    {
        // 3 Groups: Group 0 (5 members), Group 1 (3 members), Group 2 (6 members)
        Member[][] companyGroups = new Member[3][];
        companyGroups[0] = new Member[5];
        companyGroups[1] = new Member[3];
        companyGroups[2] = new Member[6];

        bool initialized = false;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n================ COMPANY MANAGEMENT MENU ================");
            Console.WriteLine("1. Initialize Member Data (Pre-assigned or Manual)");
            Console.WriteLine("2. Print List of All Members");
            Console.WriteLine("3. Search Member Information by ID");
            Console.WriteLine("4. Find Member with Highest Completed Tasks");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    InitializeData(companyGroups);
                    initialized = true;
                    break;
                case "2":
                    if (CheckInit(initialized)) PrintAllMembers(companyGroups);
                    break;
                case "3":
                    if (CheckInit(initialized))
                    {
                        Console.Write("Enter Member ID to search: ");
                        string searchId = Console.ReadLine() ?? "";
                        SearchMemberById(companyGroups, searchId);
                    }
                    break;
                case "4":
                    if (CheckInit(initialized)) PrintTopTaskMember(companyGroups);
                    break;
                case "5":
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static bool CheckInit(bool initialized)
    {
        if (!initialized)
        {
            Console.WriteLine("Please initialize the member data first (Option 1).");
            return false;
        }
        return true;
    }

    // Task 1: Initialize Array
    static void InitializeData(Member[][] groups)
    {
        Console.WriteLine("\nChoose Initialization Mode:");
        Console.WriteLine("1. Load Pre-assigned Sample Data");
        Console.WriteLine("2. Enter Data Manually");
        Console.Write("Choice: ");
        string mode = Console.ReadLine() ?? "1";

        if (mode == "2")
        {
            for (int g = 0; g < groups.Length; g++)
            {
                Console.WriteLine($"\n--- Entering Data for Group {g + 1} ({groups[g].Length} members) ---");
                for (int m = 0; m < groups[g].Length; m++)
                {
                    Console.WriteLine($"Member {m + 1}:");
                    Console.Write("  Enter ID: ");
                    string id = Console.ReadLine() ?? "";
                    Console.Write("  Enter Full Name: ");
                    string name = Console.ReadLine() ?? "";
                    Console.Write("  Enter Completed Tasks: ");
                    int tasks = int.Parse(Console.ReadLine() ?? "0");

                    groups[g][m] = new Member(id, name, tasks);
                }
            }
            Console.WriteLine("Manual initialization complete!");
        }
        else
        {
            // Pre-assigned sample data
            groups[0] = new Member[]
            {
                new Member("M101", "Alice Smith", 14),
                new Member("M102", "Bob Johnson", 8),
                new Member("M103", "Charlie Brown", 22),
                new Member("M104", "David Miller", 11),
                new Member("M105", "Emma Davis", 19)
            };

            groups[1] = new Member[]
            {
                new Member("M201", "Fiona Wilson", 17),
                new Member("M202", "George Clark", 31),
                new Member("M203", "Hannah White", 25)
            };

            groups[2] = new Member[]
            {
                new Member("M301", "Ian Thomas", 5),
                new Member("M302", "Julia Martin", 12),
                new Member("M303", "Kevin Anderson", 28),
                new Member("M304", "Laura Taylor", 9),
                new Member("M305", "Michael Lee", 15),
                new Member("M306", "Nina Harris", 20)
            };

            Console.WriteLine("Pre-assigned sample data loaded successfully!");
        }
    }

    // Task 2: Print All Members
    static void PrintAllMembers(Member[][] groups)
    {
        Console.WriteLine("\n================ ALL MEMBERS LIST ================");
        for (int i = 0; i < groups.Length; i++)
        {
            Console.WriteLine($"\n--- Group {i + 1} ({groups[i].Length} Members) ---");
            for (int j = 0; j < groups[i].Length; j++)
            {
                if (groups[i][j] != null)
                {
                    Console.WriteLine(groups[i][j].ToString());
                }
            }
        }
    }

    // Task 3: Print Member Info by ID
    static void SearchMemberById(Member[][] groups, string id)
    {
        bool found = false;
        for (int i = 0; i < groups.Length; i++)
        {
            for (int j = 0; j < groups[i].Length; j++)
            {
                if (groups[i][j] != null && groups[i][j].Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"\nMember Found in Group {i + 1}:");
                    Console.WriteLine(groups[i][j].ToString());
                    found = true;
                    break;
                }
            }
            if (found) break;
        }

        if (!found)
        {
            Console.WriteLine($"No member found with ID '{id}'.");
        }
    }

    // Task 4: Print Member with Highest Completed Tasks
    static void PrintTopTaskMember(Member[][] groups)
    {
        Member topMember = null;
        int maxGroup = -1;

        for (int i = 0; i < groups.Length; i++)
        {
            for (int j = 0; j < groups[i].Length; j++)
            {
                if (groups[i][j] != null)
                {
                    if (topMember == null || groups[i][j].CompletedTasks > topMember.CompletedTasks)
                    {
                        topMember = groups[i][j];
                        maxGroup = i + 1;
                    }
                }
            }
        }

        if (topMember != null)
        {
            Console.WriteLine("\n================ TOP PERFORMER ================");
            Console.WriteLine($"Group: {maxGroup}");
            Console.WriteLine(topMember.ToString());
        }
        else
        {
            Console.WriteLine("No members found in system.");
        }
    }
}