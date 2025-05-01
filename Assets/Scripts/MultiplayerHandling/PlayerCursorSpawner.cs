using UnityEngine;
using Unity.Netcode;


public class PlayerCursorSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject networkCursorUIPrefab;
    private Canvas uiCanvas;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            RequestCursorSpawnServerRpc();
        }
    }

    [ServerRpc]
    private void RequestCursorSpawnServerRpc(ServerRpcParams rpcParams = default)
    {
        GameObject canvasObj = GameObject.FindGameObjectWithTag("CursorCanvas");
        Canvas uiCanvas = canvasObj?.GetComponent<Canvas>();

        if (uiCanvas == null)
        {
            Debug.Log("No canvas found in scene.");
            return;
        }

        GameObject cursor = Instantiate(networkCursorUIPrefab);
        

        var netObj = cursor.GetComponent<NetworkObject>();
        netObj.SpawnWithOwnership(OwnerClientId); //Assign ownership to the requesting client

        //Reparent after spawning
        //cursor.transform.SetParent(uiCanvas.transform, false); //false keeps local positioning
    }

}

