using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Used for navigation by the player pawn.
/// </summary>
public class RingSlots : MonoBehaviour
{
    // each ring will be 10 units long.
    [SerializeField]
    List<RingData> rings = new List<RingData>();

    /// <summary>
    /// 
    /// </summary>
    public List<RingData> Rings
    {
        get
        {
            return rings;
        }
    }

}

