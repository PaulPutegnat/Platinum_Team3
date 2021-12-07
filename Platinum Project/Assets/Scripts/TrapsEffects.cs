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
    private Color _windowColor;

    private void Awake()
    {
        if (instanceTrapsEffects != null && instanceTrapsEffects != this)
            Destroy(gameObject);

        instanceTrapsEffects = this;
    }

    private void Start()
    {
        _testcam = FindObjectOfType<Camera>().GetComponent<TestCam>();
        _windowColor = BrokenScreen.GetComponent<Renderer>().material.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(BrokenScreenFadeIn());
        }
    }
    
    public void BrokenScreenEffect()
    {
        StartCoroutine(BrokenScreenFadeIn());
    }

    public IEnumerator CameraSpeed()
    {
        Debug.Log("Speed Up!");
        _testcam.speedUp = speedMultiplicator;
        yield return new WaitForSeconds(speedTrapDuration);
        _testcam.speedUp = 1;
    }

    public IEnumerator BrokenScreenFadeIn()
    {
        while (_windowColor.a > 0)
        {
            float fadeAmount = _windowColor.a + (0.5f * Time.deltaTime);

            _windowColor = new Color(_windowColor.r, _windowColor.g, _windowColor.b, fadeAmount);
            yield return null;
        }
    }
}
