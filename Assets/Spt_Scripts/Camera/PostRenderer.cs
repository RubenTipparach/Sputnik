using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PostRenderer : MonoBehaviour {

    [SerializeField]
    private Material _lineMat;

    private List<DrawCircleWrapper> circleDrawers = new List<DrawCircleWrapper>();
    private List<DrawLineWrapper> lineDrawers = new List<DrawLineWrapper>();

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnPostRender()
    {
        foreach(var circle in circleDrawers)
        {
           GLLines.CircleDrawing(_lineMat, circle.color, circle.iteration, circle.radius, circle.source, circle.rotatiom);
        }

        foreach(var line in lineDrawers)
        {
            GLLines.LineDrawing(_lineMat, line.color, line.source, line.destination);
        }
    }

    /// <summary>
    /// Add circle drawings here.
    /// </summary>
    /// <param name="dcw"></param>
    public void AddCircleDrawer(DrawCircleWrapper dcw)
    {
        circleDrawers.Add(dcw);
    }

    /// <summary>
    /// Add line drawings here.
    /// </summary>
    /// <param name="dlw"></param>
    public void AddLineDrawer(DrawLineWrapper dlw)
    {
        lineDrawers.Add(dlw);
    }
}

public class DrawCircleWrapper
{
    public Color color;
    public int iteration;
    public float radius;
    public Vector3 source;
    public Quaternion rotatiom;
}

public class DrawLineWrapper
{
    public Color color;
    public Vector3 source;
    public Vector3 destination;
}