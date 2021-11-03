using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    public bool loop = false;
    public float TimeFromLastToFirstTarget;
    public PointInfo[] PointsInfos;

    private int i = 0;
    private float _timer = 0;
    private float _percent;
    private bool _canIncrement = false;

    private bool _positionSettings = false;
    private Vector3 _startPosition;

    private bool _rotationSettings = false;
    private Quaternion _startRotation;

    private bool _fovSettings = false;
    private float _startFov;

    void Update()
    {
        _timer += Time.deltaTime;
        _percent = (PointsInfos[i].StepDuration > 0) ? _timer / PointsInfos[i].StepDuration : 1f;

        if (i < PointsInfos.Length)
        {
            if (PointsInfos[i].ChangePosition)
            {
                if (!_positionSettings)
                {
                    _startPosition = Camera.main.transform.position;
                    _positionSettings = true;
                }
                MoveCamera();
            }

            if (PointsInfos[i].ChangeRotation)
            {
                if (!_rotationSettings)
                {
                    _startRotation = Camera.main.transform.rotation;
                    _rotationSettings = true;
                }
                RotateCamera();
            }

            if (PointsInfos[i].ChangeFov)
            {
                if (!_fovSettings)
                {
                    _startFov = Camera.main.fieldOfView;
                    _fovSettings = true;
                }
                ChangeFov();
            }

            if (_canIncrement && i < PointsInfos.Length - 1)
            {
                i++;
                _canIncrement = false;
            }
        }

        else if (loop && i == PointsInfos.Length - 1)
        {
            GetLoopingTargets();
        }
    }

    public void MoveCamera()
    {
        Vector3 currentPosition = _startPosition;
        Vector3 targetPosition = PointsInfos[i].Target.transform.position;

        transform.position = Vector3.Lerp(currentPosition, targetPosition, _percent);

        if (transform.position == targetPosition)
        {
            _timer = 0;
            _canIncrement = true;
            _positionSettings = false;
        }
    }

    public void RotateCamera()
    {
        Quaternion currentRotation = _startRotation;
        Quaternion targetRotation = PointsInfos[i].Target.transform.rotation;

        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, _percent);

        if (transform.rotation == targetRotation)
        {
            _timer = 0;
            _canIncrement = true;
            _rotationSettings = false;
        }
    }

    public void ChangeFov()
    {
        float currentFov = _startFov;
        float targetFov = PointsInfos[i].Fov;

        Camera.main.fieldOfView = Mathf.Lerp(currentFov, targetFov, _percent);

        if (Camera.main.fieldOfView == targetFov)
        {
            _timer = 0;
            _canIncrement = true;
            _fovSettings = false;
        }
    }

    public void GetLoopingTargets()
    {
        Transform currentPosition = PointsInfos[PointsInfos.Length - 1].Target.transform;
        Transform targetPosition = PointsInfos[0].Target.transform;

        float duration = TimeFromLastToFirstTarget;
        float percent = (duration > 0) ? _timer / duration : 1f;

        transform.position = Vector3.Lerp(currentPosition.position, targetPosition.position, percent);

        if (transform.position == targetPosition.position)
        {
            _timer = 0;
            i = 0;
        }
    }
}