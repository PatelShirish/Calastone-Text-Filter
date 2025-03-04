namespace Calastone_Text_Filter.Filters
{
    public class VowelInMiddleFilter : ITextFilter
    {
        private readonly HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u',
                                                                    'A', 'E', 'I', 'O', 'U' };

        public bool ShouldFilter(string word)
        {
            int len = word.Length;
            
            // odd word
            if (len % 2 == 1)
            {
                int mid = len / 2;
                return vowels.Contains(word[mid]);
            }
            else // even word
            {
                int mid1 = len / 2 - 1;
                int mid2 = len / 2;
                return vowels.Contains(word[mid1]) || vowels.Contains(word[mid2]);
            }
        }
    }
}
