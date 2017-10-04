using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BustAMove {
    public class ArrowControl : MonoBehaviour {
        public float speed;
        public Transform shootPoint;

        public void Update() {
            float horMove = Input.GetAxis("Horizontal");
            Move(horMove);
        }

        public void Move(float axis) {
            if (transform.eulerAngles.z <= -90) {
                if (axis > 0) {
                    axis = 0;
                }
            }
            if (transform.eulerAngles.z >= 90) {
                if (axis < 0) {
                    axis = 0;
                }
            }
            Debug.DrawRay(shootPoint.position, transform.up * 5, Color.red);
            Debug.Log(transform.eulerAngles.z);
            this.transform.Rotate(0.0f, 0.0f, -axis * speed);

            //transform.Rotate(Vector3.right * axis * Time.deltaTime);
        }



    }
}

