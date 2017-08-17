using System;
using System.Collections.Generic;

namespace VideoMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menueItems = {
                "Search for a video",
                "Create a video",
                "Open a video",
                "Modify a video",
                "Delete a video",
                "Exit"
            };

            List<Video> videos = new List<Video>();

            int selection = showMenue(menueItems);

            
            if (selection == 1)
            {
                //Search for a video
                Console.WriteLine(menueItems[selection-1]);
            }
            else if (selection == 2)
            {
                 //Create a video
                Console.WriteLine(menueItems[selection - 1]);
                createVideo(videos);
            }
            else if (selection == 3)
            {
                //Open a video
                Console.WriteLine(menueItems[selection - 1]);
                openVideoList(videos);
            }
            else if (selection == 4)
            {
                //Modify a video
                Console.WriteLine(menueItems[selection - 1]);
            }
            else if (selection == 5)
            {
                //Delete a video
                Console.WriteLine(menueItems[selection - 1]);
            }else if (selection == 5)
            {
                //Exit
                Console.WriteLine("Bye Bye");
            }

            Console.ReadLine();
        }

        private static void createVideo(List<Video> videos)
        {
            Console.WriteLine("Type in a name: ");
            string name = Console.ReadLine();
            Video video = new Video()
            {
                VideoName = name
            };
            videos.Add(video);
        }


    private static void openVideoList(List<Video> videos)
        {
            Console.WriteLine("Your videos: ");
            if (videos.Count == 0)
            {
                Console.WriteLine("You have no videos.");
            } else
            {
                foreach (var video in videos)
                {
                    Console.WriteLine(video);
                }
            }
        }

        private static int showMenue(string[] menueItems)
        {
            Console.Clear();
            Console.WriteLine("Select what you want to do: \n");
            for (int i = 0; i < menueItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)} : {menueItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection <1 || selection >5)
            {
                Console.WriteLine("Type in a number between 1 and 5");
            }
            return selection;
        }
    }
}