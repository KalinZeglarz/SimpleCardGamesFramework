using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class OpponentConfiguration : NetworkBehaviour
{
    void Start()
    {
        if (isServer)
        {
            GetComponent<OponentController>().enabled = false;
            GetComponent<Image>().sprite = GetComponent<OponentController>().back;
        }
        if (isClient)
        {
            GetComponent<OponentController>().enabled = true;
            GetComponent<Image>().sprite = GetComponent<OponentController>().front;
        }
    }

    void Update()
    {
        if (isServer)
        {
            if (GetComponent<OponentController>().inBox) GetComponent<Image>().sprite = GetComponent<OponentController>().front;
            else GetComponent<Image>().sprite = GetComponent<OponentController>().back;
        }
    }
}
