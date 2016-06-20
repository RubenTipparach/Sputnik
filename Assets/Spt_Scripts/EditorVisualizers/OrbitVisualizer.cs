using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Couples with the editor script to let you tweak the orbits of planets.
/// </summary>
[ExecuteInEditMode]
public class OrbitVisualizer : MonoBehaviour
{
    /// <summary>
    /// The number of turns it takes for one polar coordinate cell to be passed.
    /// </summary>
    [SerializeField]
    private int _turnsPerCell;

    private SolarSystem _sol;

    private OrbitGuides _guide;

    void Start()
    {
        _sol = transform.parent.GetComponent<SolarSystem>();
    }

	void Update()
    {
        _guide = GetComponent<OrbitGuides>();

        if (_guide != null)
        {
            DebugDrawer.CircleDrawing(Color.green, 32, _guide.Distance, _sol.transform.position, Quaternion.identity);

            DebugDrawer.CircleDrawing(Color.magenta, 32, GetComponent<SphereCollider>().radius * transform.localScale.magnitude/2, 
                transform.position - new Vector3(0, transform.position.y, 0)
                , Quaternion.identity);

            Debug.DrawLine(transform.position, transform.position - new Vector3(0, transform.position.y, 0), Color.magenta);
        }
    }
}

