using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConfiguration : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (isLocalPlayer)
        {
            GetComponentInChildren<Canvas>().enabled = true;
        }
        if (!isLocalPlayer)
        {
            GetComponent <PlayerController>().enabled = false ;
        }
    }
}
