using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PointInfo
{
    public string Step;

    public bool ChangeFov;
    public bool ChangePosition;
    public bool ChangeRotation;

    public GameObject TargetPosition;
    public GameObject TargetRotation;
    public int Fov;
    public float StepDuration;
}
