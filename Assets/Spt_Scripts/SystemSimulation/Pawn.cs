using UnityEngine;
using System.Collections;

public class Pawn : MonoBehaviour {


    [SerializeField]
    private int _currentSlot;

    [SerializeField]
    private PawnData _pawnData;

    PawnMotion _pawnMotion;

	RingSlots _slots;

    private bool _gameStarted = false;

	// Use this for initialization
	void Awake () {
		_slots = transform.parent.GetComponent<RingSlots>();

    }

    void Start()
    {
        _pawnData = new PawnData() {
            currenLocation = transform.localPosition,
            toLocation = transform.localPosition,
            nodePosition = _currentSlot,
            slots = _slots
        };

        _pawnMotion = new PawnMotion(transform, _pawnData);

        _gameStarted = true;
    }
	
	// Update is called once per frame
	void Update ()
	{
        _pawnMotion.UpdatePosition();

        // don't forget to offset local position!
        transform.position = _pawnData.currenLocation + _slots.transform.position;
	}

    /// <summary>
    /// Ends the turn, updates the motion's position, and gets the new cordinates to inter-
    /// polate to.
    /// </summary>
	private void EndTurn()
	{
		var planets = transform.parent.GetComponent<SolarSystem>().Planets;
		foreach (var planet in planets)
		{
			planet.Run();
		}

        _pawnData.nodePosition = _currentSlot;
        _pawnMotion.RunStep();
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
            _currentSlot = value;
            EndTurn();
        }
	}

    // For the editor! lolz.
    public bool GameStarted
    {
        get
        {
            return _gameStarted;
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
