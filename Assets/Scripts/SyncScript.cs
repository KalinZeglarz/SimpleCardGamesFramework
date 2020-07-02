using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class SyncScript : NetworkBehaviour
{
    public int cardsPlayed = 0;
    public void enableCards(bool yes)
    {
        if (!yes)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.GetComponent<PlayerController>().isDraggable = false;
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                child.GetComponent<PlayerController>().isDraggable = true;
            }
        }
    }
}
