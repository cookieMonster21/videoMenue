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

            //list all videos
            List<Video> videos = new List<Video>();

            int selection = showMenue(menueItems);

            while (selection != 6)
            {
                if (selection == 1)
                {
                    //Search for a video
                    Console.WriteLine(menueItems[selection - 1]);
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
                }
                selection = showMenue(menueItems);
            }

            Console.WriteLine("Bye Bye");
            Console.ReadLine();
        }

        private static void createVideo(List<Video> videos)
        {
            int num = videos.Count +1;
            Console.WriteLine("Type in a name: ");
            string name = Console.ReadLine();
            Video video = new Video()
            {
                VideoId = num,
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
            Console.WriteLine("Select what you want to do: \n");
            for (int i = 0; i < menueItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)} : {menueItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection <1 || selection >6)
            {
                Console.WriteLine("Type in a number between 1 and 6");
            }
            return selection;
        }
    }
}