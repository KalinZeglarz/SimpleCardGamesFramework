using UnityEngine;
using Assets.Database;
using UnityEngine.UI;

public class AddGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        GamesDb mGamesDb = new GamesDb();
        var gameName = GameObject.FindWithTag("GameName").GetComponent<InputField>();
        var gameDescription = GameObject.FindWithTag("GameDescription").GetComponent<InputField>();

        mGamesDb.AddData(new GameEntity(gameName.text, gameDescription.text));
        mGamesDb.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
