using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// v = Sqrt(G * M_central) / R
/// M = mass, G = 6.673 x 10-11 N•m2/kg2
/// R = radius
/// http://www.physicsclassroom.com/class/circles/Lesson-4/Mathematics-of-Satellite-Motion
/// </summary>
public class PlanetaryMotion
{
	/// <summary>
	/// The transform.
	/// </summary>
	private Transform _transform;

	/// <summary>
	/// The planet data.
	/// </summary>
	private PlanetaryData _planetData;

	/// <summary>
	/// Initializes a new instance of the <see cref="PlanetaryMotion"/> class.
	/// Using these clases as independent simulation systems.
	/// Might wanna make an MMO or something later :)
	/// </summary>
	/// <param name="transform">The transform.</param>
	public PlanetaryMotion(Transform transform, PlanetaryData planetData)
	{
		_transform = transform;
		_planetData = planetData;
    }

	/// <summary>
	/// Runs the step. Planets move counter clockwise yo.
	/// </summary>
	public void RunStep()
	{
		_planetData.CurrentOrbitalPeriodPosition = (_planetData.CurrentOrbitalPeriodPosition + 1) % _planetData.TotalOrbitalPeriod;

		float yDegree = ((float)_planetData.PeriodMovementPerTurn / (float)_planetData.TotalOrbitalPeriod) * 360.0f ;
		Debug.Log("rotating by" + yDegree);
        _transform.RotateAround(_transform.GetComponent<Planet>().HostStar.transform.position, Vector3.up, yDegree);
		// blah blah blah whatever.
		//_transform.position = 
	}
}