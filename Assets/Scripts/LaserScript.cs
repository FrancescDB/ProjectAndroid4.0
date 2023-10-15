using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    private int poolSize;
    [SerializeField] List<GameObject> laserList;

    private static LaserScript instance;
    public static LaserScript Instance { get { return instance;  } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        poolSize = 20;

        AddLasersToPool(poolSize);
    }

    private void AddLasersToPool(int amount)
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject laser = Instantiate(laserPrefab);
            laser.SetActive(false);
            laserList.Add(laser);
            laser.transform.parent = transform;
        }
    }

    public GameObject RequestLaser()
    {
        for (int i = 0; i < laserList.Count; i++)
        {
            if (!laserList[i].activeSelf)
            {
                laserList[i].SetActive(true);
                return laserList[i];
            }
        }
        AddLasersToPool(1);
        laserList[laserList.Count - 1].SetActive(true);
        return laserList[laserList.Count - 1];
    }
}
