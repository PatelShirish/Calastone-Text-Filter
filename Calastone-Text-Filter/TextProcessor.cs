using Calastone_Text_Filter.Filters;
using System.Text.RegularExpressions;

namespace Calastone_Text_Filter
{
    public class TextProcessor
    {
        private IEnumerable<ITextFilter> _filters;

        private static readonly Regex regex = new Regex(@"\W+", RegexOptions.Compiled);

        public TextProcessor(IEnumerable<ITextFilter> filters)
        {
            this._filters = filters;
        }

        public IEnumerable<string> ProcessText(string filePath)
        {
            // Read and process each line concurrently, also preserve the order
            return File.ReadLines(filePath)
                       .AsParallel()
                       .AsOrdered()
                       .SelectMany(line => regex.Split(line))
                       .Where(word => !string.IsNullOrWhiteSpace(word) && !_filters.Any(filter => filter.ShouldFilter(word)));
        }
    }
}
