using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class RingData
{
    public int distance;

    public float degree;

    public int[] connections;

    public Vector3 LocalPosition
    {
        get
        {
            return Quaternion.Euler(0, degree, 0) * Vector3.forward * distance;
        }
    }
}
