using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInTime
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 velocity;
    public PointInTime(Vector3 _position, Vector3 _velocity, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
        velocity = _velocity;
    }
}
