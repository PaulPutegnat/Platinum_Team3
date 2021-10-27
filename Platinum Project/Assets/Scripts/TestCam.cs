using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine.InputSystem;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    public bool loop = false;
    public float DurationFromLastToFirstTarget;
    public PointInfo[] PointsInfos;

    private int i = 0;
    private float Timer = 0;

    void Update()
    {
        Timer += Time.deltaTime;

        if (i < PointsInfos.Length - 1)
        {
            GetTargets();
        }

        else
        {
            GetLoopingTargets();
        }
    }

    public void GetTargets()
    {
        Transform currentPosition = PointsInfos[i].Target.transform;
        Transform targetPosition = PointsInfos[i + 1].Target.transform;

        float durationToTarget = PointsInfos[i].DurationToNextTarget;
        float durationToFov = PointsInfos[i].DurationToFov;
        float percent = (durationToTarget > 0) ? Timer / durationToTarget : 1f;
        float fovPercent = Timer / durationToFov;

        transform.position = Vector3.Lerp(currentPosition.position, targetPosition.position, percent);
        Camera.main.fieldOfView = Mathf.Lerp(60, 90, fovPercent);


        if (transform.position == targetPosition.position)
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

        float duration = DurationFromLastToFirstTarget;
        float percent = (duration > 0) ? Timer / duration : 1f;

        transform.position = Vector3.Lerp(currentPosition.position, targetPosition.position, percent);

        if (transform.position == targetPosition.position)
        {
            Timer = 0;
            i = 0;
        }
    }
}