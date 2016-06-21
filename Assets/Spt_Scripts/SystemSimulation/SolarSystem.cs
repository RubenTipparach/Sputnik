using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// The solar system simulator.
/// </summary>
public class SolarSystem : MonoBehaviour
{
    [SerializeField]
    Star _star;

    [SerializeField]
    List<Planet> _planets;

    /// <summary> 
    /// This represents a deterministic solar system update interval.
    /// Usually happens at the end of a turn.
    /// </summary>
    /// <remarks>Sputnik uses non-newtonian physics,
    /// rather it uses Decorative Interstellar Turn-Based Physics (DIT-P)</remarks>
    //public void UpdateSimulation()
    //{

    //} Planets move according to their planetary data stuff.
	//delegatiions cool, so what do we do with the solar system?

	public Star HostStar
	{
		get
		{
			return _star;
		}
	}
}

