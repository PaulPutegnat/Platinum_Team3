using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ShootingGame : MonoBehaviour
{
    public GameObject _spawnArea;
    private RectTransform _spawnAreaRT;
    public GameObject _targetPrefab;
    public GameObject _aimSightP1;
    public GameObject _aimSightP2;
    public GameObject _aimSightP3;
    public Transform _targetList;

    [Header("Tweakable")]
    public float _aimSpeed = 2f;
    public int _nbTarget;
    public float _shrinkingTimer;
    public float _disapearTimer;
    public int _points;
    public float _cameraSpeedReward;

    private float nextSpawnTime;
    private Vector2 padPosP1;
    private Vector2 padPosP2;
    private bool IsP1Shooting = false;
    private bool IsP2Shooting = false;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    private PlayerInput p1Input;
    private PlayerInput p2Input;

    void Start()
    {
        _spawnAreaRT = _spawnArea.GetComponent<RectTransform>();
        this.gameObject.transform.localPosition = new Vector3(0f, 0f, -10f);

        //Fetch the Raycaster from the GameObject (the Canvas)
        m_Raycaster = FindObjectOfType<GraphicRaycaster>();
        //Fetch the Event System from the Scene
        m_EventSystem = FindObjectOfType<EventSystem>();

        if (GameManager.gameManager.players[3])
        {
            _aimSightP2.SetActive(true);
            p2Input = GameManager.gameManager.players[3].GetComponent<PlayerInput>();
        }
        else
        {
            _aimSightP2.SetActive(false);
        }

        p1Input = GameManager.gameManager.players[2].GetComponent<PlayerInput>();
        Debug.Log(p1Input);
        
    }

    void Update()
    {
        if (GameManager.gameManager.players[2])
        {
            IsP1Shooting = p1Input.actions.FindAction("ShootP1").triggered;
            padPosP1 = p1Input.actions.FindAction("AimingP1").ReadValue<Vector2>();
            _aimSightP1.transform.Translate(padPosP1 * _aimSpeed * Time.deltaTime);
        }

        if (GameManager.gameManager.players[3])
        {
            IsP2Shooting = p2Input.actions.FindAction("ShootP2").triggered;
            padPosP2 = p2Input.actions.FindAction("AimingP2").ReadValue<Vector2>();
            _aimSightP2.transform.Translate(padPosP2 * _aimSpeed * Time.deltaTime);
        }

        if (Time.time > nextSpawnTime)
        {
            SpawnTarget();
        }

        if (IsP1Shooting)
        {
            Debug.Log("P1 is Shooting");
            Vector3 sightPos = _aimSightP1.GetComponent<RectTransform>().position;

            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Camera.main.WorldToScreenPoint(sightPos);

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            if (results.Count == 0)
            {
                Debug.Log("results.Count = 0");
                return;
            }

            GameObject firstTarget = results[0].gameObject;
            GameObject hitTarget = null;

            

            if (results.Count == 1)
            {
                Debug.Log("results.Count = 1");
                if (results[0].gameObject.CompareTag("Target"))
                {
                    hitTarget = firstTarget;
                }
            }
            else
            {
                foreach (RaycastResult h in results)
                {
                    if (h.gameObject.CompareTag("Target") && h.gameObject.GetComponent<RectTransform>())
                    {
                        if (firstTarget != h.gameObject)
                        {
                            if (firstTarget.GetComponent<RectTransform>())
                            {
                                if (h.gameObject.GetComponent<RectTransform>().localPosition.z < firstTarget.GetComponent<RectTransform>().localPosition.z)
                                {
                                    hitTarget = h.gameObject;
                                }
                            }
                            else
                            {
                                hitTarget = h.gameObject;
                            }
                        }
                    }
                }
            }

            if (hitTarget != null)
            {
                if (hitTarget.CompareTag("Target")) 
                {
                    _points++;
                    Debug.Log("points : :" + _points);
                    Destroy(hitTarget.gameObject);
                }
            }
        }

        if (IsP2Shooting)
        {
            Debug.Log("P2 is Shooting");
            Vector3 sightPos = _aimSightP2.GetComponent<RectTransform>().position;

            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Camera.main.WorldToScreenPoint(sightPos);

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            if (results.Count == 0)
            {
                Debug.Log("results.Count = 0");
                return;
            }

            GameObject firstTarget = results[0].gameObject;
            GameObject hitTarget = null;



            if (results.Count == 1)
            {
                Debug.Log("results.Count = 1");
                if (results[0].gameObject.CompareTag("Target"))
                {
                    hitTarget = firstTarget;
                }
            }
            else
            {
                foreach (RaycastResult h in results)
                {
                    if (h.gameObject.CompareTag("Target") && h.gameObject.GetComponent<RectTransform>())
                    {
                        if (firstTarget != h.gameObject)
                        {
                            if (firstTarget.GetComponent<RectTransform>())
                            {
                                if (h.gameObject.GetComponent<RectTransform>().localPosition.z > firstTarget.GetComponent<RectTransform>().localPosition.z)
                                {
                                    hitTarget = h.gameObject;
                                }
                            }
                            else
                            {
                                hitTarget = h.gameObject;
                            }
                        }
                    }
                }
            }

            if (hitTarget != null)
            {
                if (hitTarget.CompareTag("Target"))
                {
                    _points++;
                    Debug.Log("points : :" + _points);
                    Destroy(hitTarget.gameObject);
                }
            }
        }
    }

    public void SpawnTarget()
    {
        Vector3 size = _spawnAreaRT.sizeDelta;
        Vector3 pos = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-10f, -20f));
        GameObject newTarget = Instantiate(_targetPrefab, _targetList);
        newTarget.transform.localPosition = pos;
        newTarget.transform.localScale = new Vector3(.5f, .5f, .5f);
        nextSpawnTime = Time.time + 1f;
    }
}
