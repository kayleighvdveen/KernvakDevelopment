using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove {
    public class GameController : MonoBehaviour {
        public GameObject PauseMenu;

        public void Update() {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (PauseMenu.activeSelf == true) {
                    PauseMenu.SetActive(false);
                } else {
                    PauseMenu.SetActive(true);
                }             
            }
        }
    }
}