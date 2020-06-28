using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerConfiguration : NetworkBehaviour
{
    void Start()
    {
        if (isServer) GetComponent<OponentController>().enabled = false;


        if (isClient) GetComponent<PlayerController>().enabled = false;

    }

    void Update()
    {
        if (isClient && GetComponent<PlayerController>() != null)
        {
            if (GetComponent<PlayerController>().inBox) GetComponent<Image>().sprite = GetComponent<PlayerController>().front;
            else GetComponent<Image>().sprite = GetComponent<PlayerController>().back;
        }
        if (isServer && GetComponent<OponentController>() != null)
        {
            if (GetComponent<OponentController>().inBox) GetComponent<Image>().sprite = GetComponent<OponentController>().front;
            else GetComponent<Image>().sprite = GetComponent<OponentController>().back;
        }
    }
}
