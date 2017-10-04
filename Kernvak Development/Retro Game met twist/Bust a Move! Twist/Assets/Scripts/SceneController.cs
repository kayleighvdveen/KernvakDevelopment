using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BustAMove {
    public class SceneController : MonoBehaviour {

        public void LoadByIndex(int sceneNumber) {
            SceneManager.LoadScene(sceneNumber);
        }

        public void Quit() {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
