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

        transform.Translate(new Vector3(right, 0, forward));
    }
}
