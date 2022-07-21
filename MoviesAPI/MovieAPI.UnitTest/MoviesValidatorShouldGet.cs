
using MoviesAPI.Models;

namespace MovieAPI.UnitTest
{
    public class MoviesValidatorShouldGet
    {
        [Fact]
        public void GetMovies_ReturnsNotEmpty()
        {
            string path = @"../../../Utilities/Movies.Json";
            var streamReaderJSON = new StreamReaderJSON<Movie>();
            var data = streamReaderJSON.Get(path);

            Assert.NotEmpty(data);
        }
    }
}