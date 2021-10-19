using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCam : MonoBehaviour
{

    public bool _left;
    public bool _right;
    public bool _up;
    public bool _down;

    public bool _zeroX;
    public bool _zeroY;

    [Range(-15f, 15f)]
    public float _speedX;    
    [Range(-15f, 15f)]
    public float _speedY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_speedX, _speedY, 0) * Time.deltaTime;

        //Active le boolean _right
        if(_speedX > 0)
        {
            _left = false;
            _right = true;
            _zeroX = false;
        }
        //Active le boolean _left
        else if (_speedX < 0)
        {
            _left = true;
            _right = false;
            _zeroX = false;
        }
        //Active le boolean _zeroX
        else
        {
            _zeroX = true;
            _left = false;
            _right = false;
        }



        //Active le boolean _up
        if (_speedY > 0)
        {
            _down = false;
            _up = true;
            _zeroY = false;
        }
        //Active le boolean _down
        else if (_speedY < 0)
        {
            _down = true;
            _up = false;
            _zeroY = false;
        }
        //Active le boolean _zeroY
        else
        {
            _zeroY = true;
            _down = false;
            _up = false;
        }
    }
}
