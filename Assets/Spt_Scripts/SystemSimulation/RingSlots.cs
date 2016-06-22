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
	/// The goal.
	/// </summary>
	[SerializeField]
	RingData goal;

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

	public RingData Goal 
	{
		get
		{
			return goal;
		}
	}

	/// <summary>
	/// Starts this instance.
	/// </summary>
	void Start()
	{
		var postRenderer = Camera.main.GetComponent<PostRenderer>();

		// define goal
		postRenderer.AddCircleDrawer(new DrawCircleWrapper()
		{
			color = new Color(.7f, .5f,.0f),
			iteration = 16,
			radius = 1,
			source = transform.position + goal.LocalPosition,
			rotatiom = Quaternion.identity,
			mat = LineMat.mat2
		});

		// define slots
		foreach (var slot in rings)
		{
			postRenderer.AddCircleDrawer(new DrawCircleWrapper()
			{
				color = Color.blue,
				iteration = 16,
				radius = 1,
				source = transform.position + slot.LocalPosition,
				rotatiom = Quaternion.identity,
				mat = LineMat.mat2
			});

			// Debug.DrawLine(transform.position + slot.LocalPosition, transform.position, Color.red);


			// Draw connections between nodes
			for (int i = 0; i < slot.connections.Length; i++)
			{
				//Debug.Log("LineDrawn");
				postRenderer.AddLineDrawer(new DrawLineWrapper()
				{
					source = transform.position + slot.LocalPosition,
					destination = transform.position + rings[slot.connections[i]].LocalPosition,
					color = Color.red,
					mat = LineMat.mat2
				});
			}

			if(slot.goesToGoal)
			{
				postRenderer.AddLineDrawer(new DrawLineWrapper()
				{
					source = transform.position + slot.LocalPosition,
					destination = transform.position + goal.LocalPosition,
					color = Color.white,
					mat = LineMat.mat2
				});
			}
		}
	}

	void Update()
	{

	}
}

