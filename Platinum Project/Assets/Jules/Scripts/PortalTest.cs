using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PortalTest : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject SliderPrefab;
    private Slider SliderGameObject;
    private GameObject newGameObject;

    [Header("Tweakable")] 
    public float decreaseSpeed;
    public int UpValue;
    public float sliderMaxValue;
    public Vector3 SliderOffset;

    private PlayerInput playerInputP1;
    private PlayerInput playerInputP2;

    private float sliderCurrentValue;
    private Transform portalCanvas;

    private bool IsP1Pressing = false;
    private bool IsP2Pressing = false;
    private bool IsInTheZone = false;
    private bool IsAlreadyInstantiate = false;
    private bool IsRunning = false;

    private void Start()
    {
        portalCanvas = GameObject.FindGameObjectWithTag("PortalUI").transform;
    }
    void Update()
    {
        if (IsInTheZone)
        {

            IsP1Pressing = InputManager.inputManager.PortalP1();

            if (GameManager.gameManager.players[1] != null)
            {
                IsP2Pressing = InputManager.inputManager.PortalP2();
            }
            

            if (!IsAlreadyInstantiate)
            {
                newGameObject = Instantiate(SliderPrefab, portalCanvas);
                SliderGameObject = newGameObject.GetComponent<Slider>();
                SliderGameObject.maxValue = sliderMaxValue;
                IsAlreadyInstantiate = true;
            }

            Vector3 ThisPos = this.gameObject.transform.parent.position;
            newGameObject.transform.localPosition = Vector3.zero;
            portalCanvas.position = ThisPos + SliderOffset;
            //newGameObject.transform.localPosition = this.transform.position;

            if (IsP1Pressing && IsAlreadyInstantiate)
            {
                sliderCurrentValue += UpValue;
            }

            if (IsP2Pressing && IsAlreadyInstantiate)
            {
                sliderCurrentValue += UpValue;
            }

            if (SliderGameObject.value > 0)
            {
                sliderCurrentValue -= Time.deltaTime * decreaseSpeed;

                if (sliderCurrentValue >= sliderMaxValue)
                {
                    Destroy(this.transform.parent.gameObject);
                    Destroy(newGameObject);
                }
            }

            SliderGameObject.value = sliderCurrentValue;
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsInTheZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsInTheZone = false;
            Destroy(newGameObject);
            IsAlreadyInstantiate = false;
            sliderCurrentValue = 0;
        }
    }
}
