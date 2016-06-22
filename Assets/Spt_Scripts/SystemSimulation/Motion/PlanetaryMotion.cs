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
/// <remarks>
/// Lol I ended up using none of that crap!
/// </remarks>
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

    private float _currentDegree = 0;

    private float _toDegree = 0;

    private float yAmount = 0;

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

        _currentDegree = ((float)_planetData.PeriodMovementPerTurn / (float)_planetData.TotalOrbitalPeriod) * 360.0f;
        _toDegree = _currentDegree;

        yAmount = _transform.position.y;
    }

    /// <summary>
    /// Runs the step. Planets move counter clockwise yo.
    /// </summary>
    public void RunStep()
	{
        //the modulus thing makes it lerp backwards
        _planetData.CurrentOrbitalPeriodPosition = (_planetData.PeriodMovementPerTurn + _planetData.CurrentOrbitalPeriodPosition);// % _planetData.TotalOrbitalPeriod;

        _toDegree = ((float)_planetData.CurrentOrbitalPeriodPosition  / (float)_planetData.TotalOrbitalPeriod) * 360.0f ;
		//Debug.Log("rotating by" + yDegree);
		// blah blah blah whatever.
		//_transform.position = 
	}

    public void UpdatePosition()
    {
        _currentDegree = Mathf.Lerp(_currentDegree, _toDegree, Time.deltaTime * 10);

        //Debug.Log("_currentDegree " + _currentDegree);
        //_transform.RotateAround(_transform.GetComponent<Planet>().HostStar.transform.position, Vector3.up, _currentDegree);
        _transform.position = Quaternion.Euler(Vector3.up * _currentDegree)
            * _transform.GetComponent<Planet>().HostStar.transform.forward
            * _planetData.StellarDistance + Vector3.up * yAmount;
    }
}