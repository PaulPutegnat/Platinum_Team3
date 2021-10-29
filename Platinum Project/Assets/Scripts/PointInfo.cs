using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointInfo
{
    public string Name;

    public bool ChangeFov;
    public bool ChangePosition;
    public bool ChangeRotation;

    public GameObject Target;
    public int Fov;
    public float TimeToFov;
    public float TimeToNextPosition;
    public float TimeToRotate;
}
