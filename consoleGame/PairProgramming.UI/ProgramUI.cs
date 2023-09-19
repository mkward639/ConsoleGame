using static System.Console;
using PairProgramming.Data.Entities;
using PairProgramming.Repository.ProjectItemRepository;
using PairProgramming.Data.Entities.Enums;

namespace PairProgramming.UI
{
    public class ProgramUI
    {
        // private readonly ProjectItemRepo _projRepo = new ProjectItemRepo();
        private readonly PathEncounterRepo _pathEncounterRepo = new PathEncounterRepo();
        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;

            while (isRunning)
            {
                //* Game Code goes here!
                WriteLine("Welcome\n" +
                                        "1. Start Game.\n" +
                                        "2. Exit App\n");
                string userInput = ReadLine()!;

                switch (userInput)
                {
                    case "1":
                        StartGame();
                        break;

                    case "2":
                        isRunning = ExitApplication();
                        break;

                    default:
                        WriteLine("Invalid Selection");
                        break;
                }
            }
        }

        private void StartGame()
        {
            Console.Clear();
            System.Console.WriteLine("It's dusk and you find out the forest you're in is Haunted!");
            System.Console.WriteLine("You need to navigate through the Forest in order to get to safety.\n" +
                                        "Which path will you take?");
            DisplayPathOption();
            string userInput = Console.ReadLine();
            int conversionInt = int.Parse(userInput);
            PathOption selectedPath = (PathOption)conversionInt; //! <---- Turns int -> PathOption
            if (selectedPath == PathOption.Left)
            {
                Console.Clear();
                System.Console.WriteLine("The path is blocked by zombies\n" +
                                        " \n" +
                                        "Choose a number for what to do next.\n");
                var PathOption = _pathEncounterRepo.GetPathOptionsById(1);
                //*This is where the user makes a choice
                foreach (var option in PathOption)
                {
                    System.Console.WriteLine(option);
                }
                var userInputZombieEncounter = int.Parse(Console.ReadLine());
                var actaulSelectedValue = PathOption[userInputZombieEncounter - 1];
                if (actaulSelectedValue == "3. Pick up the crowbar next to you to defend yourself")
                {
                    GoToLocation2();
                }
                else
                {
                    Death();
                }
            }

            if (selectedPath == PathOption.Right)
            {
                System.Console.WriteLine("you've come to a dead end and were swarmed by ghosts.");
                Thread.Sleep(2000);
                Death();
            }

            if (selectedPath == PathOption.Center)
            {
                System.Console.WriteLine("The path leads on forever.");
                Thread.Sleep(2000);
                Death();
            }

            ReadKey();

        }
        private void GoToLocation2()
        {
            Clear();
            System.Console.WriteLine("Well done! You fought your way through the zombies and now you are approaching the swamp. \n" +
                        "Press any key to continue.");
            Console.ReadKey();
            Clear();
            Console.WriteLine("You've made it to the Swamp! Which path will you take now?");

            DisplayPathOption();
            string userInput = Console.ReadLine();
            int conversionInt = int.Parse(userInput);
            PathOption selectedPath = (PathOption)conversionInt;
            if (selectedPath == PathOption.Left)
            {
                System.Console.WriteLine("You walk into a spiderweb and are eaten by a giant spider.");
                Thread.Sleep(2000);
                Death();
            }
            if (selectedPath == PathOption.Right)
            {
                System.Console.WriteLine("You stepped into a pool of acid with floating bones.");
                Thread.Sleep(2000);
                Death();
            }

            if (selectedPath == PathOption.Center)
            {
                Console.Clear();
                System.Console.WriteLine("Shrek comes out of nowhere and blocks the path! \n" +
                                        "\n" +
                                        "Choose a number for what to do next.\n" +
                                        "\n");
                var PathOption = _pathEncounterRepo.GetPathOptionsById(2);
                //*This is where the user makes a choice
                foreach (var option in PathOption)
                {
                    System.Console.WriteLine(option);
                }
                var userinputshrekEncounter = int.Parse(Console.ReadLine());
                var actaulSelectedValue = PathOption[userinputshrekEncounter - 1];
                if (actaulSelectedValue == "2. Use the force on him.")
                {
                    GoToLocation3();
                }
                else
                {
                    Death();
                }
            }

        }

        private void GoToLocation3()
        {
            Clear();
            System.Console.WriteLine("Shrek stands no chance against the power of the force.\n" + "It is now your swamp. \n" +
                        "Press any key to continue.");
            Console.ReadKey();
            Clear();
            Console.WriteLine("You leave your newfound swamp to continue to the shed! Which path will you take now?\n" +
                                "Choose your final path to esacpe the forest...");

            DisplayPathOption();
            string userInput = Console.ReadLine();
            int conversionInt = int.Parse(userInput);
            PathOption selectedPath = (PathOption)conversionInt;
            if (selectedPath == PathOption.Left)
            {
                System.Console.WriteLine("1.Continue to run as fast as you can..");
                Thread.Sleep(2000);
                Death();
            }
            if (selectedPath == PathOption.Right)
            {
                System.Console.WriteLine("2. Climb a tree.");
                Thread.Sleep(2000);
                Death();
            }

            if (selectedPath == PathOption.Center)
            {
                Console.Clear();
                System.Console.WriteLine("Dracula flies out of the shed after you ! \n" +
                                        "\n" +
                                        "Choose a number for what to do next.\n" +
                                        "\n");
                var PathOption = _pathEncounterRepo.GetPathOptionsById(3);
                //*This is where the user makes a choice
                foreach (var option in PathOption)
                {
                    System.Console.WriteLine(option);
                }
                var userinputdraculaEncounter = int.Parse(Console.ReadLine());
                var actaulSelectedValue = PathOption[userinputdraculaEncounter - 1];
                if (actaulSelectedValue == "3. Throw garlic in his face and stab him with a wooden stake.")
                {
                    System.Console.WriteLine("Congratulations! You escaped the forest!");
                    Thread.Sleep(2000);
                    ExitApplication();
                }
                else
                {
                    Death();
                }
            }
        }

        private void Death()
        {
            System.Console.WriteLine("You died! Try Again.");
            System.Console.WriteLine("Do you want to try again? y/n");
            var userInput = Console.ReadLine();
            if (userInput.ToLower() == "Y".ToLower())
            {
                StartGame();
            }
            else
            {
                ExitApplication();
            }
        }




        private void DisplayPathOption()
        {
            System.Console.WriteLine($"1. Left\n" +
                                        "2. Right\n" +
                                        "3. Center\n");
        }

        private bool ExitApplication()
        {
            Console.Clear();
            Console.WriteLine("Thanks for Playing! Press any Key.");
            Console.ReadKey();
            return false;
        }

        // private void AddProjectItem()
        // {
        //     Console.Clear();
        //     var proItem = new ProjectItem();

        //     Console.WriteLine("== Add Project Item ==");
        //     Console.WriteLine("Please input Project Item Name:");

        //     string userInputName = Console.ReadLine()!;

        //     proItem.Name = userInputName;

        //     if(_projRepo.AddProjectItem(proItem))
        //     Console.WriteLine("Success!");
        //     else
        //     Console.WriteLine("FAIL!");

        //     Console.WriteLine("Press any Key to Continue...");
        //     Console.ReadKey();
        // }
    }
}