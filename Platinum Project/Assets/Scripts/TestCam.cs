using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine.InputSystem;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    public bool loop = false;
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

        else if (loop)
        {
            i = 0;
        }
    }

    public void GetTargets()
    {
        Transform currentPosition = PointsInfos[i].Target.transform;
        Transform targetPosition = PointsInfos[i + 1].Target.transform;

        float duration = PointsInfos[i].Duration;
        float percent = (duration > 0) ? Timer / duration : 1f;

        transform.position = Vector3.Lerp(currentPosition.position, targetPosition.position, percent);

        if (transform.position == targetPosition.position)
        {
            Timer = 0;

            if (i < PointsInfos.Length)
            {
                i++;
            }
        }
    }
}