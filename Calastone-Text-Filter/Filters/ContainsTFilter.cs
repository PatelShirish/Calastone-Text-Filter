namespace Calastone_Text_Filter.Filters
{
    public class ContainsTFilter : ITextFilter
    {
        public bool ShouldFilter(string word)
        {
            return word.Contains('t', StringComparison.OrdinalIgnoreCase);
        }
    }
}
