using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private Vector2 mousePos;
    private Vector2 padPos;
    private bool IsP1Shooting = false;
    private bool IsP2Shooting = false;

    void Start()
    {
        _spawnAreaRT = _spawnArea.GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnTarget();
        }

        _aimSightP1.transform.Translate(padPos * _aimSpeed * Time.deltaTime);

        if (IsP1Shooting)
        {
            Debug.Log("Shoot");
            RaycastHit2D[] hit = Physics2D.RaycastAll(padPos, Vector3.back);

            if (hit.Length == 0)
            {
                return;
            }

            GameObject firstTarget = hit[0].collider?.gameObject;
            GameObject hitTarget = null;

            if (hit.Length == 1)
            {
                if (hit[0].collider.gameObject.CompareTag("Target"))
                {
                    hitTarget = firstTarget;
                    Debug.Log(hitTarget);
                }
            }
            else
            {
                foreach (RaycastHit2D h in hit)
                {
                    if (h.collider.gameObject.CompareTag("Target") && h.collider.gameObject.GetComponent<RectTransform>())
                    {
                        if (firstTarget != h.collider.gameObject)
                        {
                            if (firstTarget.GetComponent<RectTransform>())
                            {
                                if (h.collider.gameObject.GetComponent<RectTransform>().localPosition.z > firstTarget.GetComponent<RectTransform>().localPosition.z)
                                {
                                    hitTarget = h.collider.gameObject;
                                }
                            }
                            else
                            {
                                hitTarget = h.collider.gameObject;
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
            RaycastHit2D[] hit = Physics2D.RaycastAll(padPos, Vector2.zero);

            if (hit.Length == 0)
            {
                return;
            }

            GameObject firstTarget = hit[0].collider?.gameObject;
            GameObject hitTarget = null;
            if (hit.Length == 1)
            {
                if (hit[0].collider.gameObject.CompareTag("Target"))
                {
                    hitTarget = firstTarget;
                }
            }
            else
            {
                foreach (RaycastHit2D h in hit)
                {
                    if (h.collider.gameObject.CompareTag("Target") && h.collider.gameObject.GetComponent<RectTransform>())
                    {
                        if (firstTarget != h.collider.gameObject)
                        {
                            if (firstTarget.GetComponent<RectTransform>())
                            {
                                if (h.collider.gameObject.GetComponent<RectTransform>().localPosition.z > firstTarget.GetComponent<RectTransform>().localPosition.z)
                                {
                                    hitTarget = h.collider.gameObject;
                                }
                            }
                            else
                            {
                                hitTarget = h.collider.gameObject;
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
                    Debug.Log(_points);
                    Destroy(hitTarget.gameObject);
                }
            }
        }

        mousePos = Mouse.current.position.ReadValue();

    }

    public void SpawnTarget()
    {
        Vector3 size = _spawnAreaRT.sizeDelta;
        Vector3 pos = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), transform.position.z);
        GameObject newTarget = Instantiate(_targetPrefab, _targetList);
        newTarget.transform.localPosition = pos;
        newTarget.transform.localScale = new Vector3(.5f, .5f, .5f);
        nextSpawnTime = Time.time + 1f;
    }

    public void GetPadPos(InputAction.CallbackContext context)
    {
        padPos = context.action.ReadValue<Vector2>();
    }

    public void P1Shooting(InputAction.CallbackContext context)
    {
        IsP1Shooting = context.action.triggered;
    }

    public void P2Shooting(InputAction.CallbackContext context)
    {
        IsP2Shooting = context.action.triggered;
    }
}
