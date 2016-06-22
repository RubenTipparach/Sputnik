using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// The pawn is your game piece, a satillite, warship or whatever.
/// This is for the player.
/// May or may not use for enemy in future iteration.
/// </summary>
public class PawnMotion
{
    private Pawn _pawn;

    private Transform _transform;

    private PawnData _pawnData;

    private Vector3 _currenLocation = Vector3.zero;

    private Vector3 _toLocation = Vector3.zero;

    /// <summary>
    /// Data should initialize to whatever state is in the system at start.
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="data"></param>
    public PawnMotion(Transform transform, PawnData data)
    {
        _pawn = transform.GetComponent<Pawn>();
        _transform = transform;
        _pawnData = data;
    }

    /// <summary>
    /// Implement turn based changes here.
    /// </summary>
    /// <remarks>
    /// Could definitely be turned into interface.
    /// </remarks>
    public void RunStep()
    {
        _pawnData.toLocation = _pawnData.slots.Rings[_pawnData.nodePosition].LocalPosition;
    }

    public void UpdatePosition()
    {
        // configure this!
        _pawnData.currenLocation = Vector3.Lerp(_pawnData.currenLocation, _pawnData.toLocation, Time.deltaTime * 10);
    }
}


public class PawnData
{
    [HideInInspector]
    public Vector3 currenLocation;

    [HideInInspector]
    public Vector3 toLocation;

    [HideInInspector]
    public int nodePosition;

    [HideInInspector]
    public RingSlots slots;

    public float interpolationVal;
}

