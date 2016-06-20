using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class DebugDrawer
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    /// <param name="iteration"></param>
    /// <param name="radius"></param>
    /// <param name="source"></param>
    /// <param name="rotatiom"></param>
    public static void CircleDrawing(Color color, int iteration, float radius, Vector3 source, Quaternion rotatiom)
    {
        Vector3[] vi = new Vector3[iteration+ 1];

        for (int i = 1; i <= iteration + 1; i++)
        {
            float dg = i;
            float n = iteration;

            Vector3 v = Vector3.zero;

            v.x = radius * Mathf.Cos((dg / n) * Mathf.PI * 2);
            v.z = radius * Mathf.Sin((dg / n) * Mathf.PI * 2);
            v = rotatiom * v;

            Vector3 v1 = new Vector3(v.x + source.x, v.y + source.y, v.z + source.z);
            Vector3 start = new Vector3(v1.x, v1.y, v1.z);
            Vector3 end = start;

            if (i != 1 && i != iteration + 1)
            {
                end = new Vector3(v.x + source.x, v.y + source.y, v.z + source.z);
            }
            //Debug.Log("start " + start + " end " + end);
            vi[i - 1] = start;
        }

        // draw from array, a bit different than GL Lines
        for (int i = 0; i < iteration; i++)
        {
            Debug.DrawLine(vi[i], vi[i+1], color);
        }
    }

}

