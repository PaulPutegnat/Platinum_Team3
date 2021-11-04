using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine.InputSystem;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class TestCam : MonoBehaviour
{
    public PointInfo[] PointsInfos;

    private int i = 0;
    private float _timer = 0;
    private float _percent;
    private bool _canIncrement = false;

    private bool _positionSettings = false;
    private Vector3 _currentPosition;

    private bool _rotationSettings = false;
    private Quaternion _currentRotation;

    private bool _fovSettings = false;
    private float _currentFov;

    void Update()
    {
        _timer += Time.deltaTime;
        _percent = _timer / PointsInfos[i].StepDuration;

        if (i < PointsInfos.Length)
        {
            if (PointsInfos[i].ChangePosition)
            {
                if (!_positionSettings)
                {
                    _currentPosition = Camera.main.transform.position;
                    _positionSettings = true;
                }
                MoveCamera();
            }

            if (PointsInfos[i].ChangeRotation)
            {
                if (!_rotationSettings)
                {
                    _currentRotation = Camera.main.transform.rotation;
                    _rotationSettings = true;
                }
                RotateCamera();
            }

            if (PointsInfos[i].ChangeFov)
            {
                if (!_fovSettings)
                {
                    _currentFov = Camera.main.fieldOfView;
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
    }

    public void MoveCamera()
    {
        Vector3 currentPosition = _currentPosition;
        Vector3 targetPosition = PointsInfos[i].TargetPosition.transform.position;

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
        Quaternion currentRotation = _currentRotation;
        Quaternion targetRotation = PointsInfos[i].TargetRotation.transform.rotation;

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
        float currentFov = _currentFov;
        float targetFov = PointsInfos[i].Fov;

        Camera.main.fieldOfView = Mathf.Lerp(currentFov, targetFov, _percent);

        if (Camera.main.fieldOfView == targetFov)
        {
            _timer = 0;
            _canIncrement = true;
            _fovSettings = false;
        }
    }
}