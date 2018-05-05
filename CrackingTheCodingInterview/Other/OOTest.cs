using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Amazon
{
    class OOTest
    {
        Report GetReport(DateTime from, DateTime to)
        {
            var viewingSessions = GetViewingSessions(from, to);
            var genresWatched = new List<ReportGroup>();
            foreach (var viewingSession in viewingSessions)
            {
                // get the genra;
                foreach (var genre in viewingSession.VideoWatched.Genres)
                {
                    if (!genresWatched.Any(g => g.Genre == genre))
                    {
                        genresWatched.Add(new ReportGroup(genre));
                    }
                    genresWatched.Single(g => g.Genre == genre).Price += viewingSession.Price;
                }
                // add to a gro
            }
            return new Report(genresWatched);
        }
        List<ViewingSession> GetViewingSessions(DateTime from, DateTime to)
        {
            return new List<ViewingSession>();
        }
    }
    class Report
    {
        public Report(List<ReportGroup> groups)
        {
            Groups = groups;
        }
        public List<ReportGroup> Groups;
    }
    class ReportGroup
    {
        public ReportGroup(Genre genre)
        {
            Genre = genre;
            Price = 0;
        }
        public Genre Genre;
        public decimal Price;
    }
    class Genre
    {
        public string Name;
    }
    class Video
    {
        public List<Genre> Genres;
    }
    class ViewingSession
    {
        public Video VideoWatched;
        public DateTime Date;
        public decimal Price;
    }

}


//class Report
//{
//    public List<ReportGroup> groups;
//}
//class ReportGroup
//{
//    Genra genra;
//    decimal price;
//}
//class Genra
//{
//    public List<Video> videos;
//}
//class Video
//{
//    public List<Genra> genras;
//    public List<ViewingSession> viewingSessions;
//}
//class ViewingSession
//{
//    public Video videoWatched;
//    public Date date;
//}
//class Price
//{
//    decimal price
//}

//Report GetReport(Date from, Date to)
//{
//    var viewingSessions = GetViewingSessions(from, to);
//    var genrasWatched = new List<ReportGroup>();
//    foreach (var viewingSession in viewingSessions)
//    {
//        // get the genra;
//        foreach (var genra in viewingSession.videoWatched.Genras)
//        {
//            if (!genrasWatches.Any(g => g.genra == genra))
//            {
//                genrasWatched.add(new ReportGroup(genra));
//            }
//            genrasWatches.single(g => g.genra == genra).pirce += viewingSession.price;
//        }
//        // add to a gro
//    }
//    return new Report(genrasWatches)
//}
