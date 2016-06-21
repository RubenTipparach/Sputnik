using UnityEngine;
using System.Collections;

public class CameraPan : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");

		Vector3 rotationEuler = Camera.main.transform.rotation.eulerAngles;
		Quaternion flatRotation = Quaternion.Euler(0, rotationEuler.y, rotationEuler.z);

		transform.Translate(flatRotation * (Vector3.right * right + Vector3.forward * forward));
    }
}
