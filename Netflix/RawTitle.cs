using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix
{
    public class RawTitle : IComparable<RawTitle>
    {
        private int index;
        private string id;
        private string title;
        private int release_year;
        private double seasons;
        private double imdb_score;
        private double imdb_votes;

        public RawTitle(int index, string id, string title, int release_year, double seasons, double imdb_score, double imdb_votes)
        {
            this.index = index;
            this.id = id;
            this.title = title;
            this.release_year = release_year;
            this.seasons = seasons;
            this.imdb_score = imdb_score;
            this.imdb_votes = imdb_votes;
        }

        public int Index { get => index; set => index = value; }
        public string Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public int Release_year { get => release_year; set => release_year = value; }
        public double Seasons { get => seasons; set => seasons = value; }
        public double Imdb_score { get => imdb_score; set => imdb_score = value; }
        public double Imdb_votes { get => imdb_votes; set => imdb_votes = value; }

        public int CompareTo(RawTitle? other)
        {
            if(this is null) return 1;
            else
            {
                if (this.imdb_score < other.imdb_score) return -1;
                if (this.imdb_score > other.imdb_score) return 1;
                else
                    return 0;
            }
        }
        public override string ToString()
        {
            var culture = new CultureInfo("en-US");
            return $"{Index};{Id};{Title};{release_year};{seasons};{Convert.ToString(imdb_score, culture)};{Convert.ToString(imdb_votes, culture)}";
        }

        public override bool Equals(object? obj)
        {
            return obj is RawTitle title &&
                   index == title.index &&
                   id == title.id &&
                   this.title == title.title &&
                   release_year == title.release_year &&
                   seasons == title.seasons &&
                   imdb_score == title.imdb_score &&
                   imdb_votes == title.imdb_votes;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(index, id, title, release_year, seasons, imdb_score, imdb_votes);
        }
    }
}
