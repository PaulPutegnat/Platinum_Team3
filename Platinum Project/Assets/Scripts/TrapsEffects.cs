using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapsEffects : MonoBehaviour
{
    public static TrapsEffects instanceTrapsEffects;
    public GameObject BrokenScreen;
    public GameObject Rock;

    private TestCam _testcam;
    private float _duration = 1f;
    private float _elapsedTime;
    private float _percentageComplete;
    private bool _testRock = false;
    private Vector3 _rockStart;
    private Vector3 _rockTarget = new Vector3(0,0,0);

    private void Awake()
    {
        if (instanceTrapsEffects != null && instanceTrapsEffects != this)
            Destroy(gameObject);

        instanceTrapsEffects = this;
    }

    private void Start()
    {
        _testcam = FindObjectOfType<Camera>().GetComponent<TestCam>();
        _rockStart = Rock.transform.position;
    }

    void Update()
    {
        _percentageComplete = _elapsedTime / _duration;
        Rock.SetActive(true);
        Rock.transform.position = Vector3.Lerp(_rockStart, _rockTarget, _percentageComplete);
        
        if (Input.GetKey(KeyCode.A))
        {
            _testRock = true;
            CameraSpeed();
        }
    }
    
    public void BrokenScreenEffect()
    {
        if (_testRock)
        {
            _elapsedTime = Time.deltaTime;
            _percentageComplete = _elapsedTime / _duration;
            Rock.SetActive(true);
            Rock.transform.position = Vector3.Lerp(_rockStart, _rockTarget, _percentageComplete);

            if (_rockStart == _rockTarget)
            {
                BrokenScreen.SetActive(true);
                Debug.Log("Broken!");
                _testRock = false;
            }
        }
    }

    public void CameraSpeed()
    {
        int currentStep = _testcam.i;
        float currentStepDuration = _testcam.PointsInfos[currentStep].StepDuration;
        currentStepDuration = currentStepDuration / 2;
    }
}
