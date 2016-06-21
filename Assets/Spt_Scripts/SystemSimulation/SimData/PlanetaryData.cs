using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class PlanetaryData
{
	/// <summary>
	/// The distance from its host star/planetary center.
	/// </summary>
	public int StellarDistance;

	/// <summary>
	/// The current orbital period position. The little hand on the clock.
	/// </summary>
	public int CurrentOrbitalPeriodPosition;

	/// <summary>
	/// The total orbital period. How many slots are there in the clock
	/// </summary>
	public int TotalOrbitalPeriod;

	/// <summary>
	/// The period movement per turn.
	/// </summary>
	public int PeriodMovementPerTurn;

	/// <summary>
	/// like mass, the bigger the planet, the better the slingshot
	/// </summary> 
	public int GravitionalValue;

	/// <summary>
	/// The planet's terrain.
	/// </summary>
	public PlanetType PlanetTerrain;
}

/// <summary>
/// The planet type enum.
/// </summary>
public enum PlanetType
{
	EarthLike,
	Martian,
	Rocky,
	Desert,
	Ice,
	Volcanic,
	Cloudy,
	Acidic,
	GasGiant,
	Unknown
}