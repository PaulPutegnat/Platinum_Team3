using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGame : MonoBehaviour
{
    public SpriteRenderer spawnArea;
    public GameObject targetPrefab;

    [Header("Tweakable")]
    public int _nbTarget;
    public float _shrinkingTimer;
    public float _disapearTimer;
    public int _points;
    public float _cameraSpeedReward;

    private float nextSpawnTime;

    void Start()
    {
        
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
        Vector3 center = spawnArea.bounds.center;
        Vector3 size = spawnArea.bounds.size;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), transform.position.z);
        Instantiate(targetPrefab, pos, Quaternion.identity);
    }
}
