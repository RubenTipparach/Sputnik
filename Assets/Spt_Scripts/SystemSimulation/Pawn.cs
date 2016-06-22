using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour {

	PawnMotion _pawnMotion;

	[SerializeField]
	private int _currentSlot;

	RingSlots _slots;

	// Use this for initialization
	void Awake () {
		_slots = transform.parent.GetComponent<RingSlots>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void EndTurn()
	{

		var planets = transform.parent.GetComponent<SolarSystem>().Planets;
		foreach (var planet in planets)
		{
			planet.Run();
		}

	}

	/// <summary>
	/// Gets or sets the current slot.
	/// </summary>
	/// <value>
	/// The current slot.
	/// </value>
	public int CurrentSlot
	{
		get
		{
			return _currentSlot;
		}
		set
		{
			EndTurn();
            _currentSlot = value;
		}
	}

	/// <summary>
	/// Gets the valid slots. Options to the next connector!
	/// </summary>
	/// <value>
	/// The valid slots.
	/// </value>
	public int[] ValidSlots
	{
		get
		{
			return _slots.Rings[_currentSlot].connections;
		}
	}
}
