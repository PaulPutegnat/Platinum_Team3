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
    private float Timer = 0;

    private bool _positionSettings = false;
    private Vector3 _startPosition;
    private float _timeToMove;
    private float _positionPercent;


    private bool _rotationSettings = false;
    private Quaternion _startRotation;
    private float _timeToRotate;
    private float _rotationPercent; 


    private bool _fovSettings = false;
    private float _startFov;
    private float _timeToFov;
    private float _fovPercent;

    void Update()
    {
        Timer += Time.deltaTime;

        if (PointsInfos[i].ChangePosition && i < PointsInfos.Length)
        {
            if (!_positionSettings)
            {
                _startPosition = Camera.main.transform.position;
                _positionSettings = true;
            }
            MoveCamera();
        }

        if (PointsInfos[i].ChangeRotation && i < PointsInfos.Length)
        {
            if (!_rotationSettings)
            {
                _startRotation = Camera.main.transform.rotation;
                _rotationSettings = true;
            }
            RotateCamera();
        }

        if (PointsInfos[i].ChangeFov && i < PointsInfos.Length)
        {
            if(!_fovSettings)
            {
                _startFov = Camera.main.fieldOfView;
                _fovSettings = true;
            }
            ChangeFov();
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

        _timeToMove = PointsInfos[i].TimeToNextPosition;
        _positionPercent = (_timeToMove > 0) ? Timer / _timeToMove : 1f;

        transform.position = Vector3.Lerp(currentPosition, targetPosition, _positionPercent);

        if (transform.position == targetPosition)
        {
            Timer = 0;
            NextElement();
            _positionSettings = false;
        }
    }

    public void RotateCamera()
    {
        Quaternion currentRotation = _startRotation;
        Quaternion targetRotation = PointsInfos[i].Target.transform.rotation;

        _timeToRotate = PointsInfos[i].TimeToRotate;
        _rotationPercent = Timer / _timeToRotate;

        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, _rotationPercent);

        if (transform.rotation == targetRotation)
        {
            Timer = 0;
            NextElement();
            _rotationSettings = false;
        }
    }

    public void ChangeFov()
    {
        float currentFov = _startFov;
        float targetFov = PointsInfos[i].Fov;

        _timeToFov = PointsInfos[i].TimeToFov;
        _fovPercent = Timer / _timeToFov;

        Camera.main.fieldOfView = Mathf.Lerp(currentFov, targetFov, _fovPercent);

        if (Camera.main.fieldOfView == targetFov)
        {
            Timer = 0;
            NextElement();
            _fovSettings = false;
        }
    }

    public void NextElement()
    {
        if (_positionSettings && _rotationSettings && _fovSettings)
        {
            //Mathf.Max();
        }
        if (i < PointsInfos.Length - 1)
        {
            i++;
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