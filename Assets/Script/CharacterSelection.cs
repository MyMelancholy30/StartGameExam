using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Connection;

public class CharacterSelection : NetworkBehaviour
{
    [SerializeField] private List<GameObject> character = new List<GameObject>();
    [SerializeField] private GameObject characterSelectorPanel;
    [SerializeField] private GameObject canvasObject;

    public override void OnStartClient()
    {
        base.OnStartClient();

        if (!base.IsOwner)
            canvasObject.SetActive(false);
    }

    public void SpawnChar1()
    {
        characterSelectorPanel.SetActive(false);
        Spawn(0, LocalConnection);
    }

    public void SpawnChar2()
    {
        characterSelectorPanel.SetActive(false);
        Spawn(1, LocalConnection);
    }


    [ServerRpc(RequireOwnership = false)]

    void Spawn(int spawnIndex, NetworkConnection conn)
    {
        GameObject player = Instantiate(character[spawnIndex], SpawnPoint.instance.transform.position, rotation: (Quaternion)Quaternion.identity);
        Spawn(player, conn);
    }
}
