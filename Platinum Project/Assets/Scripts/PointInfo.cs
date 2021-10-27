using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointInfo
{
    public bool ChangeFov;
    public bool ChangePosition;
    public bool ChangeRotation;

    public GameObject Target;
    public float Fov;
    public float TimeToFov;
    public float TimeToNextTarget;
    public float TimeToRotate;
}
