using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class ShootingGame : MiniGame
{
    [Header("GameObjects")]
    public Slider TimerSlider;
    public GameObject _spawnArea;
    private RectTransform _spawnAreaRT;
    public GameObject _targetPrefab;
    public GameObject _aimSightP1;
    public GameObject _aimSightP2;
    public Transform _targetList;

    [Header("Tweakable")]
    public float _aimSpeed;
    public int _nbTarget;
    public float _shrinkingTimer;
    public float _disapearTimer;
    public int _points;

    [Header("Timer Value")]
    public float gameDuration;
    public TextMeshProUGUI timerText;
    private Color timerColor;

    private float nextSpawnTime;
    private float intervalSpawnTime;
    private Vector2 padPosP1;
    private Vector2 padPosP2;
    private bool IsP1Shooting = false;
    private bool IsP2Shooting = false;
    private RectTransform thisRT;

    public GraphicRaycasterManager graphicRaycasterManager;

    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventDataP1;
    PointerEventData m_PointerEventDataP2;

    EventSystem m_EventSystem;

    IEnumerator Start()
    {
        yield return StartCoroutine(SpawnAnimation());
        _spawnAreaRT = _spawnArea.GetComponent<RectTransform>();
        thisRT = this.gameObject.GetComponent<RectTransform>();

        m_Raycaster = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GraphicRaycaster>();
        m_EventSystem = FindObjectOfType<EventSystem>();

        if (GameManager.Instance.players[3] != null)
        {
            _aimSightP2.SetActive(true);
        }
        else
        {
            _aimSightP2.SetActive(false);
        }

        _aimSightP1.SetActive(true);

        //Timer
        TimerSlider.maxValue = gameDuration;
        timerText.text = gameDuration.ToString();
        timerColor = TimerSlider.GetComponentInChildren<Image>().color;
        timerColor = Color.green;
        intervalSpawnTime = (gameDuration / _nbTarget) - ((10 / 100) * gameDuration);

        graphicRaycasterManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<GraphicRaycasterManager>();
    }

    void Update()
    {
        if (GameManager.Instance.players[2])
        {
            IsP1Shooting = InputManager.inputManager.ShootP1();
            padPosP1 = InputManager.inputManager.AimShooterP1();

            _aimSightP1.transform.Translate(padPosP1 * _aimSpeed * Time.deltaTime);
            CheckLimit(_aimSightP1);
        }

        if (GameManager.Instance.players[3])
        {
            IsP2Shooting = InputManager.inputManager.ShootP2();
            padPosP2 = InputManager.inputManager.AimShooterP2();

            _aimSightP2.transform.Translate(padPosP2 * _aimSpeed * Time.deltaTime);
            CheckLimit(_aimSightP2);
        }

        if (Time.time > nextSpawnTime)
        {
            SpawnTarget();
        }

        if (IsP1Shooting)
        {
            Debug.Log("P1 is Shooting");
            Vector3 sightPos = _aimSightP1.GetComponent<RectTransform>().position;

            /*//Set up the new Pointer Event
            m_PointerEventDataP1 = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventDataP1.position = Camera.main.WorldToScreenPoint(sightPos);

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventDataP1, results);*/


            List<RaycastResult> results = new List<RaycastResult>();
            results = graphicRaycasterManager.Shoot(sightPos);

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
                        else
                        {
                            hitTarget = firstTarget;
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

            /*//Set up the new Pointer Event
            m_PointerEventDataP2 = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventDataP2.position = Camera.main.WorldToScreenPoint(sightPos);

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventDataP2, results);*/


            List<RaycastResult> results = new List<RaycastResult>();
            results = graphicRaycasterManager.Shoot(sightPos);


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

        if (_points > _nbTarget)
        {
            // Game finish Win
            // Win effect
            GameManager.gameManager.SpawnFortuneWheel();
            TrapsEffects.instanceTrapsEffects.BrokenScreenEffect();
            Destroy(this.gameObject);
        }

        if (gameDuration > 0)
        {
            if (gameDuration < 15f)
            {
                timerColor = new Color(1, .5f, 0);
                if (gameDuration < 5)
                {
                    timerColor = Color.red;
                }
            }
            TimerSlider.value = gameDuration;
            gameDuration -= Time.deltaTime;
        }
        else
        {
            // Game finish Lose
            // Lose effect
            GameManager.Instance.SpawnFortuneWheel();
            Destroy(this.gameObject);
        }

        timerText.text = gameDuration.ToString("f2");
    }

    public void SpawnTarget()
    {
        Vector3 size = _spawnAreaRT.sizeDelta;
        Vector3 pos = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-10f, -20f));
        GameObject newTarget = Instantiate(_targetPrefab, _targetList);
        newTarget.transform.localPosition = pos;
        newTarget.transform.localScale = new Vector3(.3f, .3f, .3f);
        nextSpawnTime = Time.time + intervalSpawnTime;
    }

    public void CheckLimit(GameObject aimSight)
    {
        Vector2 aimSightPosP1 = aimSight.transform.localPosition;
        if (aimSightPosP1.y > thisRT.sizeDelta.y)
        {
            aimSight.transform.localPosition = new Vector2(aimSight.transform.localPosition.x, thisRT.sizeDelta.y);
        }

        if (aimSightPosP1.y < 0)
        {
            aimSight.transform.localPosition = new Vector2(aimSight.transform.localPosition.x, 0);
        }

        if (aimSightPosP1.x > (thisRT.sizeDelta.x / 2))
        {
            aimSight.transform.localPosition = new Vector2((thisRT.sizeDelta.x / 2), aimSight.transform.localPosition.y);
        }

        if (aimSightPosP1.x < -(thisRT.sizeDelta.x / 2))
        {
            aimSight.transform.localPosition = new Vector2(-(thisRT.sizeDelta.x / 2), aimSight.transform.localPosition.y);
        }
    }
}
