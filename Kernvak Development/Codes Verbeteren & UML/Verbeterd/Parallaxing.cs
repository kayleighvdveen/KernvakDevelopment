using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgrounds;
    private float[] parallaxScales;

    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previousCamPos;

    private void Awake() {              
        cam = Camera.main.transform;
    }

	void Start () {
        previousCamPos = cam.position;
        parallaxScales = new float[backgrounds.Length]; 
    }
	
	void Update () {
        for (int i = 0; i < backgrounds.Length; i++) {
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
        }
        previousCamPos = cam.position;
	}
}
