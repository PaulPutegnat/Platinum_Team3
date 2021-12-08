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
    [SerializeField] private Slider TimerSlider;
    [SerializeField] private GameObject _spawnArea;
    private RectTransform _spawnAreaRT;
    [SerializeField] private GameObject _targetPrefab;
    [SerializeField] private GameObject _aimSightP1;
    [SerializeField] private GameObject _aimSightP2;
    [SerializeField] private Transform _targetList;
    [SerializeField] private GameObject _pointPrefab;

    [Header("Tweakable")]
    [SerializeField] private float _aimSpeed;
    [SerializeField] private int _nbTarget;
    [SerializeField] private int _ObjectivesPoints;
    [SerializeField] private TextMeshProUGUI _pointText;

    [Header("Timer Value")]
    [SerializeField] private float gameDuration;
    [SerializeField] private TextMeshProUGUI timerText;
    private Color timerColor;

    private float nextSpawnTime;
    private float intervalSpawnTime;
    private Vector2 padPosP1;
    private Vector2 padPosP2;
    private bool IsP1Shooting = false;
    private bool IsP2Shooting = false;
    private RectTransform thisRT;


    [SerializeField] private GraphicRaycasterManager graphicRaycasterManager;

    void Start()
    {
        StartCoroutine(SpawnAnimation());
        _spawnAreaRT = _spawnArea.GetComponent<RectTransform>();
        thisRT = this.gameObject.GetComponent<RectTransform>();

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
        IsP1Shooting = InputManager.inputManager.ShootP1();
        padPosP1 = InputManager.inputManager.AimShooterP1();

        _aimSightP1.transform.Translate(padPosP1 * _aimSpeed * Time.deltaTime);
        CheckLimit(_aimSightP1);


        IsP2Shooting = InputManager.inputManager.ShootP2();
        padPosP2 = InputManager.inputManager.AimShooterP2();

        _aimSightP2.transform.Translate(padPosP2 * _aimSpeed * Time.deltaTime);
        CheckLimit(_aimSightP2);


        if (Time.time > nextSpawnTime)
        {
            SpawnTarget();
        }

        if (IsP1Shooting)
        {
            Vector3 sightPos = _aimSightP1.GetComponent<RectTransform>().position;

            List<RaycastResult> results = new List<RaycastResult>();
            results = graphicRaycasterManager.Shoot(sightPos);

            if (results.Count == 0)
            {
                return;
            }

            GameObject firstTarget = results[0].gameObject;
            GameObject hitTarget = null;

            

            if (results.Count == 1)
            {
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
                    _ObjectivesPoints--;
                    Vector2 offset = new Vector2(1f, 1f);
                    StartCoroutine(SpawnEffect(_pointPrefab, hitTarget,offset));
                    Destroy(hitTarget.gameObject);
                }
            }
        }

        if (IsP2Shooting)
        {
            Vector3 sightPos = _aimSightP2.GetComponent<RectTransform>().position;

            List<RaycastResult> results = new List<RaycastResult>();
            results = graphicRaycasterManager.Shoot(sightPos);


            if (results.Count == 0)
            {
                return;
            }

            GameObject firstTarget = results[0].gameObject;
            GameObject hitTarget = null;

            if (results.Count == 1)
            {
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
                                if (h.gameObject.GetComponent<RectTransform>().localPosition.z >= firstTarget.GetComponent<RectTransform>().localPosition.z)
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
                    _ObjectivesPoints--;
                    Vector2 offset = new Vector2(1f, 1f);
                    StartCoroutine(SpawnEffect(_pointPrefab, hitTarget, offset));
                    Destroy(hitTarget.gameObject);
                }
            }
        }

        if (_ObjectivesPoints <= 0)
        {
            // Game finish Win
            GameManager.Instance.SpawnFortuneWheel();
            TrapsEffects.instanceTrapsEffects.TrapSelector(1);
            Destroy(this.transform.parent.gameObject);
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
            GameManager.Instance.SpawnFortuneWheel();
            Destroy(this.transform.parent.gameObject);
        }

        timerText.text = gameDuration.ToString("f2");
        _pointText.text = "Targets Left : " + _ObjectivesPoints.ToString();
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
