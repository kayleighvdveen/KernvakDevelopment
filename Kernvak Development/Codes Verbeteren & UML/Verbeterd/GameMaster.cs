using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;
	public Transform playerPrefab;
	public Transform spawnPoint;
	
    public void RespawnPlayer() {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Debug.Log("TODO: Add Spawn Particles");
    }

    public static void KillPlayer(Player player) {
        Destroy(player.gameObject);
        gm.RespawnPlayer();
    }
}
