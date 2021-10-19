using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    bool index1;
    bool index2;
    public Transform[] tracker;
    public float _speed;
    Transform currentPoint;

    private void Start()
    {
        currentPoint = tracker[0];
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (index1)
        {
            currentPoint = tracker[0];
        }
        if (index2)
        {
            currentPoint = tracker[1];
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


