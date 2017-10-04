using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public PlayerStats playerStats = new PlayerStats();

    public class PlayerStats {
        public int Health = 100;
    }
    
    public void DamagePlayer(int damage) {
        playerStats.Health -= damage;

        if (playerStats.Health <= 0) {
            Debug.Log("KILL PLAYER");
        }
    }
}
