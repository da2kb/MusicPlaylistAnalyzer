using System;

using System.Collections.Generic;

using System.IO;



namespace PlaylistAnalyzer

{

    class Program

    {

        static void Main(string[] args)

        {

            if (args.Length != 2)

            {

                Console.WriteLine("PlaylistAnalyzer <playlist_file_path> <report_file_path>");

                Environment.Exit(1);

            }



            string playlistDataFilePath = args[0];

            string reportFilePath = args[1];



            List<PlaylistStats> playlistStatsList = null;

            try

            {

                playlistStatsList = PlaylistLoader.Load(playlistDataFilePath);

            }

            catch (Exception e)

            {

                Console.WriteLine(e.Message);

                Environment.Exit(2);

            }



            var report = PlaylistReport.GenerateText(playlistStatsList);



            try

            {

                System.IO.File.WriteAllText(reportFilePath, report);

            }

            catch (Exception e)

            {

                Console.WriteLine(e.Message);

                Environment.Exit(3);

            }

        }

    }

}