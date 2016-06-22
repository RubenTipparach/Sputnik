using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PawnVisualizer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var pawn = GetComponent<Pawn>();
		var parentSystem = transform.parent.GetComponent<RingSlots>();

		transform.position = parentSystem.Rings[pawn.CurrentSlot].LocalPosition 
			+ parentSystem.transform.position.y * Vector3.up;
		
	}
}
