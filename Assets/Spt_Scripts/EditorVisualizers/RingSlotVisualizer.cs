using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[ExecuteInEditMode]
public class RingSlotVisualizer : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    void Start()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        var slots = GetComponent<RingSlots>();

        foreach(var slot in slots.Rings)
        {
            DebugDrawer.CircleDrawing(Color.blue, 16, 1,
                transform.position + slot.LocalPosition,
                Quaternion.identity);

            Debug.DrawLine(transform.position + slot.LocalPosition, transform.position, Color.red);


            // Draw connections between nodes
            for (int i = 0; i < slot.connections.Length; i++)
            {
                
                Debug.Log("LineDrawn");
                Debug.DrawLine(transform.position + slot.LocalPosition, 
                    transform.position + slots.Rings[i].LocalPosition, Color.red);
            }
        }
    }
}

