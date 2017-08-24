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
            string[] menueItems = {
                "Search for a video",
                "Create a video",
                "Open all videos",
                "Modify a video",
                "Delete a video",
                "Exit"
            };

            int selection = showMenue(menueItems);

            while (selection != 6)
            {
                if (selection == 1)
                {
                    Console.WriteLine(menueItems[selection - 1]);
                    searchVideo();
                }
                else if (selection == 2)
                {
                    Console.WriteLine(menueItems[selection - 1]);
                    createVideo();
                }
                else if (selection == 3)
                {
                    Console.WriteLine(menueItems[selection - 1]);
                    openVideo();
                }
                else if (selection == 4)
                {
                    Console.WriteLine(menueItems[selection - 1]);
                    modifyVideo();
                }
                else if (selection == 5)
                {
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
            if (bllFacade.VideoService.emptyDatabase())
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
                Video video = bllFacade.VideoService.Search(search);
                if (video != null)
                {
                    Console.WriteLine($"Name: {video.VideoName}, ID: {video.VideoId}");
                }
                else
                {
                    Console.WriteLine($"There is no video with {search}");
                }
            }
        }


        private static void modifyVideo()
        {
            if (bllFacade.VideoService.emptyDatabase())
            {
                Console.WriteLine("You have no videos.");
            }
            else
            {
                Console.WriteLine("Choose the ID from the video you want to modify: ");
                showVideoList();
                int selection = CorrectInput();
                Video tempVideo = bllFacade.VideoService.Get(selection);
                string oldname = tempVideo.VideoName;
                Console.Write("Type in the new name: ");
                string newname = Console.ReadLine();
                while (newname.Length < 3)
                {
                    Console.WriteLine("The name need three or more letters: ");
                    newname = Console.ReadLine();
                }
                tempVideo.VideoName = newname;
                bllFacade.VideoService.Modify(tempVideo);
                Console.WriteLine($"You changed {oldname} to {newname}");
            }
        }

        private static void deleteVideo()
        {
            if (bllFacade.VideoService.emptyDatabase())
            {
                Console.WriteLine("You have no videos.");
            }
            else
            {
                Console.WriteLine("Choose the ID from the video you want remove: ");
                showVideoList();
                int selection = CorrectInput();
                Console.WriteLine($" You removed: {bllFacade.VideoService.Get(selection).VideoName}, ID: {bllFacade.VideoService.Get(selection).VideoId}");
                bllFacade.VideoService.Delete(selection);
            }
        }

        private static int CorrectInput()
        {
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || !bllFacade.VideoService.IdInDatabase(selection))
            {
                Console.WriteLine("Choose an ID from the list above: ");
            }
            return selection;
        }

        private static void showVideoList()
        {
            List<Video> video = bllFacade.VideoService.ReadAll();
            for (int i = 0; i < video.Count; i++)
            {
                Console.WriteLine($"ID: {video[i].VideoId}; Name: {video[i].VideoName}");
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
            if (bllFacade.VideoService.emptyDatabase())
            {
                Console.WriteLine("You have no videos.");
            }
            else
            {
                Console.WriteLine("Your videos: ");
                showVideoList();
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