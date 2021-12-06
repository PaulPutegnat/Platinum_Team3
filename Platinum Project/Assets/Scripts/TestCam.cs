using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class TestCam : MonoBehaviour
{
    public PointInfo[] PointsInfos;

    [HideInInspector] public int i = 0;
    private float _timer = 0;
    private float _percent;
    private bool _canIncrement = false;

    private bool _positionSettings = false;
    private Vector3 _currentPosition;

    private bool _rotationSettings = false;
    private Vector3 _currentRotation;
    private Vector3 _currentEulerAngle;

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
                    _currentRotation = _currentEulerAngle;
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

            TimerOver();

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
    }

    public void RotateCamera()
    {
        Vector3 currentRotation = _currentRotation;
        Vector3 targetRotation = PointsInfos[i].TargetRotation;

        _currentEulerAngle = Vector3.Lerp(currentRotation, targetRotation, _percent);
        transform.eulerAngles = _currentEulerAngle;
    }

    public void ChangeFov()
    {
        float currentFov = _currentFov;
        float targetFov = PointsInfos[i].Fov;

        Camera.main.fieldOfView = Mathf.Lerp(currentFov, targetFov, _percent);
    }

    public void TimerOver()
    {
        if (_timer >= PointsInfos[i].StepDuration)
        {
            _canIncrement = true;
            _positionSettings = false;
            _rotationSettings = false;
            _fovSettings = false;
            _timer = 0;
        }
    }
}