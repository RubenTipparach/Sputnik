using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour {

	[SerializeField]
	GameObject buttonType;

	[SerializeField]
	Pawn pawn;

	List<GameObject> buttons = new List<GameObject>();
	
	// Use this for initialization
	void Start () {
		// update the current state here.
		buttons.Clear();
		NewButtonSet();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	// Should be an on hover event too.
	public void NewButtonSet()
	{
		foreach ( var b in buttons)
		{
			Destroy(b.gameObject);
			//Debug.Log("deleting " + b.gameObject.name);
		}

		buttons.Clear();

		//Debug.Log("pawn.ValidSlots.Length" + pawn.ValidSlots.Length);
        for (int i = 0; i < pawn.ValidSlots.Length; i++)
		{
			GameObject buttonGo = GameObject.Instantiate(buttonType);
			buttonGo.transform.SetParent(transform);
            buttonGo.name = "buttonChoice" + pawn.ValidSlots[i];
			
			var button = buttonGo.GetComponent<MovePawnButton>();
			button.pawnControl = pawn;
			button.ButtonText("Go to Node " + pawn.ValidSlots[i]);
			button.choiceNumber = pawn.ValidSlots[i];
			buttons.Add(buttonGo);
        }
    }
}
