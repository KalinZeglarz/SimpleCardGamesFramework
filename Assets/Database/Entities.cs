namespace Assets.Database
{
    public class CardEntity
    {
        public int CardId;
        public int GameId;
        public string Name;

        public CardEntity(int gameId, string name, int cardId = default)
        {
            if (cardId != default) CardId = cardId;
            GameId = gameId;
            Name = name;
        }
    }
    public class DeckAssignmentEntity
    {
        public int AssignmentId;
        public int CardId;
        public int DeckId;

        public DeckAssignmentEntity(int? assignmentId, int cardId, int deckId)
        {
            if (assignmentId != null) AssignmentId = (int) assignmentId;
            CardId = cardId;
            DeckId = deckId;
        }
    }

    public class DeckEntity
    {
        public int DeckId;
        public int GameId;
        public string Name;

        public DeckEntity(int? deckId, int gameId, string name)
        {
            if (deckId != null) DeckId = (int) deckId;
            GameId = gameId;
            Name = name;
        }
    }

    public class FunctionAssignmentEntity
    {
        public int AssignmentId;
        public int CardId;
        public int FunctionId;

        public FunctionAssignmentEntity(int? assignmentId, int cardId, int functionId)
        {
            if (assignmentId != null) AssignmentId = (int) assignmentId;
            CardId = cardId;
            FunctionId = functionId;
        }
    }

    public class FunctionEntity
    {
        public int FunctionId;
        public string Name;
        public string Description;

        public FunctionEntity(int? functionId, string name, string description)
        {
            if (functionId != null) FunctionId = (int) functionId;
            Name = name;
            Description = description;
        }
    }

    public class GameEntity
    {
        public int GameId;
        public string Name;
        public string Description;

        public GameEntity(string name, string description, int? gameId = null)
        {
            if (gameId != null) GameId = (int) gameId;
            Name = name;
            Description = description;
        }
    }
}