using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class NetworkManagerCore : NetworkManager
{
    private PlayerManager PlayerManager;
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
    }
}
