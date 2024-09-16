using Microsoft.AspNetCore.Mvc;
using SearchEngine.Indexing;

namespace SearchEngine.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly List<string> Data = new()
        {
            "React", "Vue", "Angular", "Svelte", "JavaScript", "TypeScript", "HTML", "CSS", "C#", "Python"
        };

        private readonly Trie _trie;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _trie = new Trie();
            PopulateSearchItems();
        }

        // Populates the Trie with search items
        private void PopulateSearchItems()
        {
            // Technology terms
            _trie.Insert("algorithm", "A step-by-step procedure for calculations.");
            _trie.Insert("api", "Application Programming Interface.");
            _trie.Insert("binary", "Base-2 numerical system.");
            _trie.Insert("cloud", "Remote servers for data storage and processing.");
            _trie.Insert("container", "A lightweight virtualized environment.");
            _trie.Insert("database", "A collection of organized data.");
            _trie.Insert("encryption", "The process of securing data.");
            _trie.Insert("firewall", "A network security system.");
            _trie.Insert("frontend", "The part of a website users interact with.");
            _trie.Insert("backend", "The server-side of a web application.");
            _trie.Insert("html", "HyperText Markup Language.");
            _trie.Insert("css", "Cascading Style Sheets.");
            _trie.Insert("javascript", "A popular programming language for the web.");
            _trie.Insert("typescript", "A superset of JavaScript with type definitions.");
            _trie.Insert("framework", "A platform for building software applications.");
            _trie.Insert("react", "A JavaScript library for building user interfaces.");
            _trie.Insert("vue", "A progressive JavaScript framework.");
            _trie.Insert("angular", "A TypeScript-based web application framework.");
            _trie.Insert("python", "A high-level programming language.");
            _trie.Insert("java", "A widely-used object-oriented programming language.");
            _trie.Insert("csharp", "A programming language developed by Microsoft.");
            _trie.Insert("docker", "A platform for developing and deploying applications.");
            _trie.Insert("kubernetes", "An orchestration platform for containers.");
            _trie.Insert("microservices", "A software architecture style.");

            // Geography terms
            _trie.Insert("africa", "The second-largest continent.");
            _trie.Insert("antarctica", "The southernmost continent.");
            _trie.Insert("asia", "The largest and most populous continent.");
            _trie.Insert("europe", "A continent north of Africa and west of Asia.");
            _trie.Insert("australia", "A country and continent in the Southern Hemisphere.");
            _trie.Insert("arctic", "The northernmost region of Earth.");
            _trie.Insert("atlantic", "The second-largest ocean on Earth.");
            _trie.Insert("pacific", "The largest and deepest of Earth's ocean basins.");
            _trie.Insert("amazon", "The world's largest rainforest.");
            _trie.Insert("sahara", "The largest hot desert in the world.");

            // General knowledge
            _trie.Insert("evolution", "The process by which species change over time.");
            _trie.Insert("gravity", "The force that attracts bodies toward the center of Earth.");
            _trie.Insert("photosynthesis", "The process by which plants make food.");
            _trie.Insert("relativity", "Einstein's theory regarding time and space.");
            _trie.Insert("quantum", "The smallest possible discrete unit of any physical property.");
            _trie.Insert("atom", "The basic unit of a chemical element.");
            _trie.Insert("molecule", "Two or more atoms bonded together.");
            _trie.Insert("electricity", "A form of energy resulting from charged particles.");
            _trie.Insert("neutron", "A subatomic particle with no charge.");
            _trie.Insert("proton", "A subatomic particle with a positive charge.");

            // Countries
            _trie.Insert("united states", "A country in North America.");
            _trie.Insert("canada", "A country in North America.");
            _trie.Insert("germany", "A country in Europe.");
            _trie.Insert("france", "A country in Europe.");
            _trie.Insert("japan", "An island country in East Asia.");
            _trie.Insert("china", "A country in East Asia.");
            _trie.Insert("india", "A country in South Asia.");
            _trie.Insert("brazil", "A country in South America.");
            _trie.Insert("australia", "A country and continent in the Southern Hemisphere.");
            _trie.Insert("south africa", "A country in Southern Africa.");

            // Famous landmarks
            _trie.Insert("eiffel tower", "A wrought-iron lattice tower in Paris.");
            _trie.Insert("great wall", "A series of walls and fortifications in China.");
            _trie.Insert("taj mahal", "A mausoleum in India.");
            _trie.Insert("statue of liberty", "A symbol of freedom in New York, USA.");
            _trie.Insert("pyramids of giza", "Ancient pyramid structures in Egypt.");
            _trie.Insert("machu picchu", "A 15th-century Inca citadel in Peru.");
            _trie.Insert("christ the redeemer", "A statue in Rio de Janeiro, Brazil.");

            // Popular cities
            _trie.Insert("new york", "A city in the United States.");
            _trie.Insert("london", "The capital city of England.");
            _trie.Insert("paris", "The capital city of France.");
            _trie.Insert("tokyo", "The capital city of Japan.");
            _trie.Insert("mumbai", "The largest city in India.");
            _trie.Insert("sydney", "A major city in Australia.");
            _trie.Insert("rio de janeiro", "A major city in Brazil.");
            _trie.Insert("berlin", "The capital city of Germany.");
            _trie.Insert("moscow", "The capital city of Russia.");
            _trie.Insert("beijing", "The capital city of China.");
        }


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // Search endpoint
        [HttpGet("search")]
        public ActionResult<IEnumerable<string>> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                // Return all items if no query is provided
                return Ok(Data);
            }

            // Perform case-insensitive search in the data
            var results = Data
                .Where(item => item.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            var secondResult = _trie.Search(query);

            if (secondResult != null)
            {

                
                return Ok(new List<string> { secondResult});
            }
            // Return the search results from the data list
            return Ok(results);

          
            
        }
    }
}
