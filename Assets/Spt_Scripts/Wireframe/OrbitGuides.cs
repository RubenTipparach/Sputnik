using UnityEngine;
using System.Collections;

[RequireComponent(typeof(OrbitVisualizer))]
public class OrbitGuides : MonoBehaviour {

    [SerializeField]
    private int _orbitalDistance;

    private DrawCircleWrapper _positionCircle;

    private DrawLineWrapper _yAxisLine;

    private SolarSystem _sol;

    // Use this for initialization
    void Start()
    {
        _sol = transform.parent.GetComponent<SolarSystem>();

        DrawCircleWrapper orbit = new DrawCircleWrapper()
        {
            color = Color.green,
            iteration = 32,
            radius = _orbitalDistance,
            source = _sol.transform.position,
            rotatiom = Quaternion.identity
        };

        _positionCircle = new DrawCircleWrapper()
        {
            color = Color.magenta,
            iteration = 32,
            radius =  GetComponent<SphereCollider>().radius * transform.localScale.magnitude / 2,
            source = transform.position - new Vector3(0, transform.position.y, 0),
            rotatiom =  Quaternion.identity
        };

        _yAxisLine = new DrawLineWrapper()
        {
            source = transform.position,
            destination = transform.position - new Vector3(0, transform.position.y, 0),
            color = Color.magenta
        };

        // The neat thing is dcw could update and the post renderer would handle the rest!
        Camera.main.GetComponent<PostRenderer>().AddCircleDrawer(orbit);
        Camera.main.GetComponent<PostRenderer>().AddCircleDrawer(_positionCircle);
        Camera.main.GetComponent<PostRenderer>().AddLineDrawer(_yAxisLine);
    }
	
	// Update is called once per frame
	void Update () {
        // update line drawing positions.
        _positionCircle.source = transform.position - new Vector3(0, transform.position.y, 0);
        _yAxisLine.source = transform.position;
        _yAxisLine.destination = transform.position - new Vector3(0, transform.position.y, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    public int Distance
    {
        get
        {
            return _orbitalDistance;
        }
    }
}
