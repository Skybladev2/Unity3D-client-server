using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Instantiate : MonoBehaviour
{
    public Transform SpaceCraft = null;


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

		if(Network.isClient)
			Debug.Log("Instaniated on client");

		if(Network.isServer)
			Debug.Log("Instaniated on server");

    }
    void OnPlayerDisconnected(NetworkPlayer player)
    {
		Network.DestroyPlayerObjects(player);
        Network.RemoveRPCs(player, 0);
        
    }

	void OnNetworkInstantiate(NetworkMessageInfo info) {
        Debug.Log("New object instantiated by " + info.sender);
    }

	void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		//foreach (var obj in viewIDs) {
		//	Network.Destroy(obj);
		//}

		//foreach (var obj in objects) {

			// уничтожаем клиентский объект	
			Destroy(GameObject.Find("Player(Clone)")); 
			// уничтожаем себя, но после первого вызова мы не сможем себя создавать
			// Network.Instantiate на клиенте перестанет работать
			//Destroy(gameObject); 
		//}
	}
}
