using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class PlayerManager : NetworkBehaviour
{
    public GameObject Card;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject DropZone;
    public GameObject OpponentDropZone;

    public bool firstTurn;

    List<GameObject> cards = new List<GameObject>();

    public override void OnStartClient()
    {
        base.OnStartClient();
        PlayerArea = GameObject.Find("PlayerHand");
        EnemyArea = GameObject.Find("OpponentHand");
        DropZone = GameObject.Find("PlayerCards");
        OpponentDropZone = GameObject.Find("OpponentCards");
    }

    [Server]
    public override void OnStartServer()
    {
        cards.Add(Card);
    }

    [Command]
    public void CmdDealCards()
    {
        Debug.Log(firstTurn);
        for (int i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCard(card, false);
        }
    }

    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
    }

    [Command]
    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, true);
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, bool inBox)
    {
        if (!inBox)
        {
            if (hasAuthority)
            {
                card.transform.SetParent(PlayerArea.transform, false);
            }
            else
            {
                card.transform.SetParent(EnemyArea.transform, false);
                card.GetComponent<CardFlip>().Flip();
            }
            if (!firstTurn) PlayerArea.GetComponent<SyncScript>().enableCards(false);
        }
        else
        {
            
            if (hasAuthority)
            {
                card.transform.SetParent(DropZone.transform, false);
                PlayerArea.GetComponent<SyncScript>().enableCards(false);
            }
            else
            {
                card.transform.SetParent(OpponentDropZone.transform, false);
                card.GetComponent<CardFlip>().Flip();
                PlayerArea.GetComponent<SyncScript>().enableCards(true);
            }
        }
    }
}
