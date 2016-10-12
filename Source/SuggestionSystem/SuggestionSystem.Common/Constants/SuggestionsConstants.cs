namespace SuggestionSystem.Common.Constants
{
    public class SuggestionsConstants
    {
        public const int TitleMinLength = 20;
        public const int TitleMaxLength = 50;

        public const int ContentMinLength = 30;
        public const int ContentMaxLength = 200;

        public const int MinimalSuggestionsPerPage = 10;
        public const int MaximalSuggestionsPerPage = 40;
        public const int RecommendedSuggestionsPerPage = 20;

        public const int DefaultPage = 1;
        public const string DefaultOrderBy = "DateCreated";
    }
}
