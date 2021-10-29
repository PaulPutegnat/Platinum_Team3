using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine.InputSystem;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    public bool loop = false;
    public float TimeFromLastToFirstTarget;
    public PointInfo[] PointsInfos;

    private int i = 0;
    private float Timer = 0;

    void Update()
    {
        Timer += Time.deltaTime;

        if (PointsInfos[i].ChangePosition && i < PointsInfos.Length - 1)
        {
            MoveCamera();
        }

        if (PointsInfos[i].ChangeRotation && i < PointsInfos.Length - 1)
        {
            RotateCamera();
        }

        if (PointsInfos[i].ChangeFov && i < PointsInfos.Length - 1)
        {
            ChangeFov();
        }
        
        else if (loop && i == PointsInfos.Length - 1)
        {
            GetLoopingTargets();
        }
    }

    public void MoveCamera()
    {
        Transform currentPosition = PointsInfos[i].Target.transform;
        Transform targetPosition = PointsInfos[i + 1].Target.transform;

        float timeToTarget = PointsInfos[i].TimeToNextPostion;
        float positionPercent = (timeToTarget > 0) ? Timer / timeToTarget : 1f;

        transform.position = Vector3.Lerp(currentPosition.position, targetPosition.position, positionPercent);

        if (transform.position == targetPosition.position)
        {
            Timer = 0;

            if (i < PointsInfos.Length)
            {
                i++;
            }
        }
    }

    public void RotateCamera()
    {
        Transform currentRotation = PointsInfos[i].Target.transform;
        Transform targetRotation = PointsInfos[i + 1].Target.transform;

        float timeToRotate = PointsInfos[i].TimeToRotate;
        float rotationPercent = Timer / timeToRotate;

        transform.rotation = Quaternion.Lerp(currentRotation.rotation, targetRotation.rotation, rotationPercent);

        if (transform.rotation == targetRotation.rotation)
        {
            Timer = 0;

            if (i < PointsInfos.Length)
            {
                i++;
            }
        }
    }

    public void ChangeFov()
    {
        float currentFov = Camera.main.fieldOfView;
        float targetFov = PointsInfos[i].Fov;

        float timeToFov = PointsInfos[i].TimeToFov;
        float fovPercent = Timer / timeToFov;

        Camera.main.fieldOfView = Mathf.Lerp(currentFov, targetFov, fovPercent);

        if (Camera.main.fieldOfView == targetFov)
        {
            Timer = 0;

            if (i < PointsInfos.Length)
            {
                i++;
            }
        }
    }

    public void GetLoopingTargets()
    {
        Transform currentPosition = PointsInfos[PointsInfos.Length - 1].Target.transform;
        Transform targetPosition = PointsInfos[0].Target.transform;

        float duration = TimeFromLastToFirstTarget;
        float percent = (duration > 0) ? Timer / duration : 1f;

        transform.position = Vector3.Lerp(currentPosition.position, targetPosition.position, percent);

        if (transform.position == targetPosition.position)
        {
            Timer = 0;
            i = 0;
        }
    }
}