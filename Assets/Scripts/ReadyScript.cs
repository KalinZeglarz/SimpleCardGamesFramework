using Mirror;

public class ReadyScript : NetworkBehaviour
{
    public PlayerManager PlayerManager;

    public void OnClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        PlayerManager.CmdDealCards();
        gameObject.SetActive(false);
    }
}
