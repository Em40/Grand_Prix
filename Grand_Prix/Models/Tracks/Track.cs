namespace Grand_Prix.Models.Tracks
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Track
    {
        public Track(int lapsNumber, int trackLength)
        {
            this.LapsNumber = lapsNumber;
            this.TrackLenght = trackLength;
            this.CurrentLap = 0;
            this.Weather = "Sunny";
        }

        public int LapsNumber { get; set; }

        public int TrackLenght { get; set; }

        public int CurrentLap { get; set; }

        public string Weather { get; set; }
    }
}
