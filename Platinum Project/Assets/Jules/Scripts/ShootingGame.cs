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
    [SerializeField] private float hitRange;
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
    private bool isGameWin = false;
    private RectTransform thisRT;

    private List<GameObject> InstTargets = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnAnimation());
        _spawnAreaRT = _spawnArea.GetComponent<RectTransform>();
        thisRT = this.gameObject.GetComponent<RectTransform>();

        if (PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER2] != null)
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
    }

    void Update()
    {
        IsP1Shooting = InputManager.inputManager.ShootP1();
        padPosP1 = InputManager.inputManager.AimShooterP1();

        _aimSightP1.transform.Translate(padPosP1 * _aimSpeed * Time.deltaTime);
        CheckLimit(_aimSightP1);

        if (PlayerManagerScript.Instance.players[PlayerManagerScript.TRAPPER2] != null)
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
            RectTransform sightPos = _aimSightP1.GetComponent<RectTransform>();
            AudioManager.Instance.PlayShotSound();
            //Vector3 sightPos = _aimSightP1.GetComponent<RectTransform>().GetWorldCorners();

            for (int i = InstTargets.Count - 1; i >= 0; i--)
            {
                GameObject target = InstTargets[i];
                float diffMag = (sightPos.position - target.transform.position).magnitude;
                if (diffMag < hitRange)
                {
                    _ObjectivesPoints--;
                    Vector2 offset = new Vector2(1f, 1f);
                    StartCoroutine(SpawnEffect(_pointPrefab, target, offset));
                    InstTargets.Remove(target);
                    Destroy(target.gameObject);
                }
            }

        }

        if (IsP2Shooting)
        {
            RectTransform sightPos = _aimSightP2.GetComponent<RectTransform>();
            AudioManager.Instance.PlayShotSound();

            for (int i = InstTargets.Count - 1; i >= 0; i--)
            {
                GameObject target = InstTargets[i];
                float diffMag = (sightPos.position - target.transform.position).magnitude;
                if (diffMag < hitRange)
                {
                    _ObjectivesPoints--;
                    Vector2 offset = new Vector2(1f, 1f);
                    StartCoroutine(SpawnEffect(_pointPrefab, target, offset));
                    InstTargets.Remove(target);
                    Destroy(target.gameObject);
                }
            }
        }

        if (_ObjectivesPoints <= 0)
        {
            // Game finish Win
            /*GameManager.Instance.SpawnFortuneWheel();
            StartCoroutine(DespawnAnimation());
            TrapsEffects.instanceTrapsEffects.TrapSelector(1);
            Destroy(this.transform.parent.gameObject);*/
            isGameWin = true;
            if (!IsGameFinishWinCoroutineStarted && isGameWin)
            {
                StartCoroutine(GameFinishWin(1));
            }
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
            if (!IsGameFinishLoseCoroutineStarted && !isGameWin)
            {
                StartCoroutine(GameFinishLose());
            }
            /*GameManager.Instance.SpawnFortuneWheel();
            StartCoroutine(DespawnAnimation());
            Destroy(this.transform.parent.gameObject);*/
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
        nextSpawnTime = Time.time + intervalSpawnTime;
        InstTargets.Add(newTarget);
        AudioManager.Instance.PlayTargetSound();

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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_aimSightP1.transform.position, hitRange);

    }
}
