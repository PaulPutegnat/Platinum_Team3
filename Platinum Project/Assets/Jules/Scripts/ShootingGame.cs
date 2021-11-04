using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGame : MonoBehaviour
{
    public GameObject _spawnArea;
    private RectTransform _spawnAreaRT;
    public GameObject _targetPrefab;
    public Transform _targetList;

    [Header("Tweakable")]
    public int _nbTarget;
    public float _shrinkingTimer;
    public float _disapearTimer;
    public int _points;
    public float _cameraSpeedReward;

    private float nextSpawnTime;
    

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
    }

    public void SpawnTarget()
    {
        Vector3 center = new Vector3((_spawnAreaRT.sizeDelta.x / 2), (_spawnAreaRT.sizeDelta.y / 2));
        Vector3 size = _spawnAreaRT.sizeDelta;
        Vector3 pos = new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), transform.position.z);
        Debug.Log("center : " + center);
        Debug.Log("size : " + size);
        Debug.Log("pos : " + pos);
        GameObject newTarget = Instantiate(_targetPrefab, _targetList);
        newTarget.transform.localPosition = pos;
        newTarget.transform.localScale = new Vector3(.5f, .5f, .5f);
        nextSpawnTime = Time.time + 1f;
    }
}
