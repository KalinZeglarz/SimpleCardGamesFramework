using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class NetworkManagerCore : NetworkManager
{
    List<NetworkConnection> connections = new List<NetworkConnection>();

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);
        connections.Add(conn);
        if(connections.Count == 2)
        {
            int random = Random.Range(0, 100);
            if (random % 2 == 0)
            {
                connections[0].identity.GetComponent<PlayerManager>().firstTurn = true;
                connections[1].identity.GetComponent<PlayerManager>().firstTurn = false;
            }
            else
            {
                connections[1].identity.GetComponent<PlayerManager>().firstTurn = true;
                connections[0].identity.GetComponent<PlayerManager>().firstTurn = false;
            }
        }
    }

    public override void OnStopServer()
    {
        base.OnStopServer();
        connections.Clear();
    }
}
