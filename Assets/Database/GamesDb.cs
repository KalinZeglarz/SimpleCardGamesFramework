using System.Data;
using UnityEngine;

namespace Assets.Database
{
    public class GamesDb : SqliteHelper
    {
        private const string Tag = "GamesDb:\t";

        private const string CardsTableName = "Cards";
        private const string DeckAssignmentsTableName = "DeckAssignments";
        private const string DecksTableName = "Decks";
        private const string FunctionAssignmentsTableName = "FunctionAssignments";
        private const string FunctionsTableName = "Functions";
        private const string GamesTableName = "Games";

        private readonly string[] _cardsColumns = { "CardID", "GameID", "Name" };
        private readonly string[] _deckAssignmentsColumns = { "AssignmentID", "CardID", "DeckID" };
        private readonly string[] _decksColumns = { "DeckID", "GameID", "Name" };
        private readonly string[] _functionAssignmentsColumns = { "AssignmentID", "CardID", "FunctionID" };
        private readonly string[] _functionsColumns = { "FunctionID", "Name", "Description" };
        private readonly string[] _gamesColumns = { "GameID", "Name", "Description" };

        public GamesDb()
        {
            IDbCommand dbcmd = GetDbCommand();
            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + CardsTableName + " ( " +
                                _cardsColumns[0] + " INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                _cardsColumns[1] + " INTEGER NOT NULL, " +
                                _cardsColumns[2] + " TEXT )";
            dbcmd.ExecuteNonQuery();

            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + DeckAssignmentsTableName + " ( " +
                                _deckAssignmentsColumns[0] + " INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                _deckAssignmentsColumns[1] + " INTEGER NOT NULL, " +
                                _deckAssignmentsColumns[2] + " INTEGER NOT NULL )";
            dbcmd.ExecuteNonQuery();

            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + DecksTableName + " ( " +
                                _decksColumns[0] + " INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                _decksColumns[1] + " INTEGER NOT NULL, " +
                                _decksColumns[2] + " TEXT )";
            dbcmd.ExecuteNonQuery();

            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + FunctionAssignmentsTableName + " ( " +
                                _functionAssignmentsColumns[0] + " INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                _functionAssignmentsColumns[1] + " INTEGER NOT NULL, " +
                                _functionAssignmentsColumns[2] + " INTEGER NOT NULL )";
            dbcmd.ExecuteNonQuery();

            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + FunctionsTableName + " ( " +
                                _functionsColumns[0] + " INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                _functionsColumns[1] + " TEXT, " +
                                _functionsColumns[2] + " TEXT )";
            dbcmd.ExecuteNonQuery();

            dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + GamesTableName + " ( " +
                                _gamesColumns[0] + " INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                _gamesColumns[1] + " TEXT, " +
                                _gamesColumns[2] + " TEXT )";
            dbcmd.ExecuteNonQuery();
        }

        public void AddData(CardEntity card)
        {
            IDbCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + CardsTableName
                               + " ( "
                               + _cardsColumns[1] + ", "
                               + _cardsColumns[2] + ") "

                               + "VALUES ( '"
                               + card.GameId + "', '"
                               + card.Name + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public void AddData(DeckAssignmentEntity deckAssignment)
        {
            IDbCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + DeckAssignmentsTableName
                               + " ( "
                               + _deckAssignmentsColumns[1] + ", "
                               + _deckAssignmentsColumns[2] + ") "

                               + "VALUES ( '"
                               + deckAssignment.CardId + "', '"
                               + deckAssignment.DeckId + "' )";
            dbcmd.ExecuteNonQuery();
        }


        public void AddData(DeckEntity deck)
        {
            IDbCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + DecksTableName
                               + " ( "
                               + _decksColumns[1] + ", "
                               + _decksColumns[2] + ") "

                               + "VALUES ( '"
                               + deck.GameId + "', '"
                               + deck.Name + "' )";
            dbcmd.ExecuteNonQuery();
        }


        public void AddData(FunctionAssignmentEntity functionAssignment)
        {
            IDbCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + FunctionAssignmentsTableName
                               + " ( "
                               + _functionAssignmentsColumns[1] + ", "
                               + _functionAssignmentsColumns[2] + ") "

                               + "VALUES ( '"
                               + functionAssignment.CardId + "', '"
                               + functionAssignment.FunctionId + "' )";
            dbcmd.ExecuteNonQuery();
        }


        public void AddData(FunctionEntity function)
        {
            IDbCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + FunctionsTableName
                               + " ( "
                               + _functionsColumns[1] + ", "
                               + _functionsColumns[2] + ") "

                               + "VALUES ( '"
                               + function.Name + "', '"
                               + function.Description + "' )";
            dbcmd.ExecuteNonQuery();
        }


        public void AddData(GameEntity game)
        {
            IDbCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "INSERT INTO " + GamesTableName
                               + " ( "
                               + _gamesColumns[1] + ", "
                               + _gamesColumns[2] + ") "

                               + "VALUES ( '"
                               + game.Name + "', '"
                               + game.Description + "' )";
            dbcmd.ExecuteNonQuery();
        }

        public override IDataReader GetDataById(string tableName, string columnName, int id)
        {
            IDbCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "SELECT * FROM " + tableName + " WHERE " + columnName +" = '" + id + "'";
            return dbcmd.ExecuteReader();
        }

        public override void DeleteDataById(string tableName, string columnName, int id)
        {
            IDbCommand dbcmd = GetDbCommand();
            dbcmd.CommandText =
                "DELETE FROM " + tableName + " WHERE " + columnName + " = '" + id + "'";
            dbcmd.ExecuteNonQuery();
        }

        public IDataReader GetAllGames()
        {
            Debug.Log(Tag + "Getting games");

            return GetAllData(GamesTableName);
        }

        public IDataReader GetAllCardsFromGame(int id)
        {
            Debug.Log(Tag + "Getting cards from : " + id);

            return GetDataById(CardsTableName, _cardsColumns[1], id);
        }

        public IDataReader GetAllFunctions(int id)
        {
            Debug.Log(Tag + "Getting functions");

            return GetAllData(FunctionsTableName);
        }

        public override void DeleteAllData()
        {
            Debug.Log(Tag + "Wiping database");

            DeleteAllData(CardsTableName);
            DeleteAllData(DeckAssignmentsTableName);
            DeleteAllData(DecksTableName);
            DeleteAllData(FunctionAssignmentsTableName);
            DeleteAllData(FunctionsTableName);
            DeleteAllData(GamesTableName);
        }
    }
}