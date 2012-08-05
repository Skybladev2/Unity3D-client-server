using UnityEngine;
using System.Collections;

public class Instantiate : MonoBehaviour
{

    private Transform SpaceCraft = null;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnNetworkLoadedLevel()
    {
        // Instantiating SpaceCraft when Network is loaded
        Network.Instantiate(SpaceCraft, transform.position, transform.rotation, 0);
    }
    void OnPlayerDisconnected(NetworkPlayer player)
    {
        Network.RemoveRPCs(player, 0);
        Network.DestroyPlayerObjects(player);
    }
}
