using System;
using System.Collections.Generic;
using VideoMenueBLL;
using VideoMeueEntity;

namespace VideoMenueUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
        
        static void Main(string[] args)
        {
            //menue
            string[] menueItems = {
                "Search for a video",
                "Create a video",
                "Open a video",
                "Modify a video",
                "Delete a video",
                "Exit"
            };

            int selection = showMenue(menueItems);

            while (selection != 6)
            {
                if (selection == 1)
                {
                    //Search for a video
                    Console.WriteLine(menueItems[selection - 1]);
                    searchVideo();
                }
                else if (selection == 2)
                {
                    //Create a video
                    Console.WriteLine(menueItems[selection - 1]);
                    createVideo();
                }
                else if (selection == 3)
                {
                    //Open a video
                    Console.WriteLine(menueItems[selection - 1]);
                    openVideo();
                }
                else if (selection == 4)
                {
                    //Modify a video
                    Console.WriteLine(menueItems[selection - 1]);
                    modifyVideo();
                }
                else if (selection == 5)
                {
                    //Delete a video
                    Console.WriteLine(menueItems[selection - 1]);
                    deleteVideo();
                }
                selection = showMenue(menueItems);
            }

            Console.WriteLine("Bye Bye");
            Console.ReadLine();
        }

        private static void searchVideo()
        {
            if (videos.Count == 0)
            {
                Console.WriteLine("You have no videos.");
            }
            else
            {
                Console.Write("Type in the first three letters: ");
                string search;
                search = Console.ReadLine();

                while (search.Length != 3)
                {
                    Console.Write("You have to type in three letters: ");
                    search = Console.ReadLine();
                }
                bool found = false;
                int result = 0;
                for (int i = 0; i < videos.Count; i++)
                {
                    string name = videos[i].VideoName.Substring(0, 3);
                    if (search == name)
                    {
                        found = true;
                        result = i;
                    }
                }
                if (found)
                {
                    Console.WriteLine($"Name: {videos[result].VideoName}, ID: {videos[result].VideoId}");
                }
                else
                {
                    Console.WriteLine($"There is no video with {search}");
                }
            }
        }


        private static void modifyVideo()
        {
            if (videos.Count == 0)
            {
                Console.WriteLine("You have no videos.");
            }
            else
            {
                Console.WriteLine("Choose the video you want to modify: ");
                showVideoList(videos);
                int selection = CorrectInput(videos);
                string oldname = videos[selection - 1].VideoName;
                Console.Write("Type in the new name: ");
                string newname = Console.ReadLine();
                videos[selection - 1].VideoName = newname;
                Console.WriteLine($"You changed {oldname} to {newname}");
            }
        }

        private static void deleteVideo()
        {
            if (videos.Count == 0)
            {
                Console.WriteLine("You have no videos.");
            }
            else
            {
                Console.WriteLine("Choose the video you want remove: ");
                showVideoList(videos);
                int selection = CorrectInput(videos);
                Console.WriteLine($" Your removed: {videos[selection - 1].VideoName}, ID: {videos[selection - 1].VideoId}");
                videos.RemoveAt(selection - 1);
            }
        }

        private static int CorrectInput(List<Video> videos)
        {
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > videos.Count)
            {
                Console.WriteLine("Choose a number from the list above: ");
            }
            return selection;
        }

        private static void showVideoList(List<Video> videos)
        {
            for (int i = 0; i < videos.Count; i++)
            {
                Console.WriteLine($" {i + 1} : {videos[i].VideoName}");
            }
        }

        private static void createVideo()
        {
            Console.WriteLine("Type in a name: ");
            string name = Console.ReadLine();

            while (name.Length < 3)
            {
                Console.WriteLine("The name need three or more letters: ");
                name = Console.ReadLine();
            }

            bllFacade.VideoService.Create(new Video()
            {
                VideoName = name
            });
        }


        private static void openVideo()
        {
            Console.WriteLine("Your videos: ");
            if (videos.Count == 0)
            {
                Console.WriteLine("You have no videos.");
            }
            else
            {
                showVideoList(videos);
                Console.Write("Select one video: ");
                int selection = CorrectInput(videos);
                Console.WriteLine($" Name: {videos[selection - 1].VideoName}, ID: {videos[selection - 1].VideoId}");
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
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 6)
            {
                Console.WriteLine("Type in a number between 1 and 6");
            }
            return selection;
        }
    }
}