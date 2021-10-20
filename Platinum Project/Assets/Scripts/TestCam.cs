using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    bool index1;
    bool index2;
    public TrackerPoint[] tracker;
    public float _speed;
    Transform currentPoint;

    private void Start()
    {
        tracker = GameObject.FindObjectsOfType<TrackerPoint>();
        currentPoint = tracker[0].Point;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (index1)
        {
            currentPoint = tracker[0].Point;
        }
        if (index2)
        {
            currentPoint = tracker[1].Point;
        }

        transform.position = Vector3.Lerp(transform.position, currentPoint.position, Time.deltaTime * _speed);
    }

    public void pressG(InputAction.CallbackContext context)
    {
        index1 = context.action.triggered;
    }

    public void pressH(InputAction.CallbackContext context)
    {
        index2 = context.action.triggered;
    }
}


