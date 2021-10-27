using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointInfo
{
    public bool IsChangingFov;

    public GameObject Target;
    public float Fov;
    public float DurationToFov;
    public float DurationToNextTarget;
}
