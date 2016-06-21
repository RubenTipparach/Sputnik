using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Can I really run this in edit mode?
/// </summary>
//[ExecuteInEditMode]
public class Planet : MonoBehaviour
{
    /// <summary>
    /// This class takes care of interpolating one point to another.
    /// Not sure how much I'll go into this.
    /// </summary>
    private PlanetaryMotion _planetMotion;

	/// <summary>
	/// The host star of our celestial body.
	/// </summary>
	private Star _star;


	/// <summary>
	/// The planet data.
	/// </summary>
	[SerializeField]
	private PlanetaryData _planetData;

	void Start()
	{
		_star = transform.parent.GetComponent<SolarSystem>().HostStar;
		_planetMotion = new PlanetaryMotion(transform, _planetData);
    }

	/// <summary>
	/// Updates this instance.
	/// </summary>
	void Update()
	{
        transform.Rotate(Vector3.up * Time.deltaTime * 10);

        // needs some interpolation ;)
        if (Input.GetKeyDown(KeyCode.T))
		{
			Run();
		}

        _planetMotion.UpdatePosition();
	}

	/// <summary>
	/// Runs this instance.
	/// </summary>
	public void Run()
	{
		Debug.Log("Updating planet " + name);
		_planetMotion.RunStep();
	}

	/// <summary>
	/// Gets the host star.
	/// </summary>
	/// <value>
	/// The host star.
	/// </value>
	public Star HostStar
	{
		get
		{
			return _star;
		}
	}
}

