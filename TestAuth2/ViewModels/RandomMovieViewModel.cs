using System.Collections.Generic;
using VidlyTest.Models;

namespace VidlyTest.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}