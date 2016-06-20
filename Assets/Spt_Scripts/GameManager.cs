using UnityEngine;
using System.Collections;

/// <summary>
///  Runs on each turn.
/// </summary>
public class GameManager : MonoBehaviour {

    bool endTurn = false;

    int turnNumber = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Updates happen instantly, all objects should move to their corresponding locations 
        // using whatever interpolation method set.
	    if(endTurn)
        {

            // update player state.

            // update enemy/npc states.

            // update planetary motion states.

            // End this turn.
            turnNumber++;
            endTurn = false;
            Debug.Log("Turn number " + turnNumber + " taken.");
        }
	}

    void TakeTurn()
    {
        endTurn = true;
    }
}
