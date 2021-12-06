using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrapsEffects : MonoBehaviour
{
    public static TrapsEffects instanceTrapsEffects;
    public GameObject BrokenScreen;
    public GameObject Rock;

    [Range(0f, 5f)] public float speedMultiplicator = 2;
    [Range(0f, 10f)] public float speedTrapDuration = 2;

    private TestCam _testcam;

    private void Awake()
    {
        if (instanceTrapsEffects != null && instanceTrapsEffects != this)
            Destroy(gameObject);

        instanceTrapsEffects = this;
    }

    private void Start()
    {
        _testcam = FindObjectOfType<Camera>().GetComponent<TestCam>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(CameraSpeed());
        }
    }
    
    public void BrokenScreenEffect()
    {

    }

    public IEnumerator CameraSpeed()
    {
        Debug.Log("Speed Up!");
        _testcam.speedUp = speedMultiplicator;
        yield return new WaitForSeconds(trapDuration);
        _testcam.speedUp = 1;
    }
}
