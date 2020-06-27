using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConfiguration : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (isServer)
        {
            GetComponent<OponentController>().enabled = false;
        }
        if (isClient)
        {
            GetComponent<PlayerController>().enabled = false;
        }
    }
}
