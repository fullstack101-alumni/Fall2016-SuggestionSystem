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

        public const string SuggestionNotExist = "Suggestion does not exist!";
        public const string SuggestionDeleted = "Suggestion successfully deleted";

        public const string NoPermissionToEdit = "You do not have permissions to edit this suggestion!";
        public const string NoPermissionToDelete = "You do not have permissions to delete this suggestion!";
        public const string NoPermissionToVote = "You do not have permission to vote for that suggestion!";
        public const string NoPermissionToComment = "You do not have permission to comment that suggestion!";
        public const string NoPermissionToView = "You do not have permission to view the suggestion's comments!";
    }
}
