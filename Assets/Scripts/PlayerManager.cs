using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerManager : NetworkBehaviour
{
    public GameObject Card;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject DropZone;
    public GameObject OpponentDropZone;

    List<GameObject> cards = new List<GameObject>();

    [SyncVar]
    int cardsPlayed = 0;

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
        for (int i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0, 0), Quaternion.identity);
            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCard(card);
        }
    }

    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
        cardsPlayed++;
    }

    [Command]
    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card);
    }

    [ClientRpc]
    void RpcShowCard(GameObject card)
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
    }
}
