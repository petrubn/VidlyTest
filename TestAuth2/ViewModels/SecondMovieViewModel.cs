using System.Collections;
using System.Collections.Generic;
using VidlyTest.Models;

namespace VidlyTest.ViewModels
{
    public class SecondMovieViewModel : IEnumerable
    {
        public List<Movie> Movies { get; set; }
        public List<Customer> Customers { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}