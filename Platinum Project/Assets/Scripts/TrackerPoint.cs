using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrackerPoint : MonoBehaviour
{
    public Transform Point;
    public float Speed;

    void Start()
    {
        Point = transform;
    }
}
