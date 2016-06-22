using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovePawnButton : MonoBehaviour {

	public Pawn pawnControl;

	public int choiceNumber;

	public Text text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	/// <summary>
	/// Terminates self, and ushers in a new generation of buttons
	/// </summary>
	public void MovePawn()
	{
		pawnControl.CurrentSlot = choiceNumber;
		transform.parent.GetComponent<ButtonManager>().NewButtonSet();
	}

	/// <summary>
	/// Buttons the text. Lol, it's a funny method.
	/// </summary>
	/// <param name="text">The text.</param>
	public void ButtonText(string text)
	{
		// WTF!
		this.text.text = text;
	}

}
