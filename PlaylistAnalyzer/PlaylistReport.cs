using System;

using System.Collections.Generic;

using System.Linq;



namespace PlaylistAnalyzer

{

    public class PlaylistReport

    {

        public static string GenerateText(List<PlaylistStats> playlistStatsList)

        {

            string report = "Playlist Analyzer Report\n\n";



            if (playlistStatsList.Count < 1)

            {

                report += "No data is available.\n";



                return report;

            }



            report += "Songs that received 200 or more plays:\n";



            var records = from playlistStats in playlistStatsList where playlistStats.Plays > 199 select playlistStats;

            if (records.Count() > 0)

            {

                foreach (PlaylistStats playlistStats in records)

                {

                    report += playlistStats + "\n";

                }

                report += "\n";

            }



            report += "Number of Alternative Songs: ";



            var altSongs = from playlistStats in playlistStatsList where playlistStats.Genre == "Alternative" select playlistStats;

            if (altSongs.Count() > 0)

            {

                int altSongsCounter = 0;

                foreach (PlaylistStats playlistStats in altSongs)

                {

                    altSongsCounter++;

                }

                report += altSongsCounter + "\n\n";

            }



            report += "Number of Hip-Hop/Rap Songs: ";



            var rapSongs = from playlistStats in playlistStatsList where playlistStats.Genre == "Hip-Hop/Rap" select playlistStats;

            if (rapSongs.Count() > 0)

            {

                int rapSongsCounter = 0;

                foreach (PlaylistStats playlistStats in rapSongs)

                {

                    rapSongsCounter++;

                }

                report += rapSongsCounter + "\n";

            }



            report += "\nSongs from the album Welcome to the Fishbowl:\n";



            var fishbowl = from playlistStats in playlistStatsList where playlistStats.Album == "Welcome to the Fishbowl" select playlistStats;

            if (fishbowl.Count() > 0)

            {

                foreach (PlaylistStats playlistStats in fishbowl)

                {

                    report += playlistStats + "\n";

                }

                report += "\n";

            }



            report += "Song names longer than 85 characters:\n";





            var nameLength = from playlistStats in playlistStatsList where playlistStats.Name.Length > 85 select playlistStats.Name;

            if (nameLength.Count() > 0)

            {

                foreach (var playlistStats in nameLength)

                {

                    report += playlistStats + "\n";

                }

                report += "\n";

            }



            var longestSong = (from playlistStats in playlistStatsList select playlistStats.Time).Max();



            report += "Longest Song:";

            var timeLength = from playlistStats in playlistStatsList where playlistStats.Time == longestSong select playlistStats;

            if (timeLength.Count() > 0)

            {

                foreach (var playlistStats in timeLength)

                {

                    report += playlistStats + "\n";

                }

                report += "\n";

            }



            return report;

        }

    }

}