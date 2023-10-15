using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InfiniteScript : MonoBehaviour
{
    private int countingEnemies;
    private int countingPowers;
    private bool randoming;
    private int enemyCount;
    private int powerCount;
    private int minEnemy;
    private int maxEnemy;
    private int minPower;
    private int maxPower;
    private float maxPosEnemy;
    private float minPosEnemy;
    private float maxPosPower;
    private float minPosPower;
    private float XPosEnemy;
    private float YPosEnemy;
    private float XPosPower;
    private float YPosPower;
    private int enemyNum;
    private int powerUpNum;
    private int enemyObj;
    private float distance;
    private bool selecting;
    private GameObject cameraObj;
    private GameObject infiniteObj;

    public GameObject car1;
    public GameObject car2;
    public GameObject enemy;
    public GameObject barrier;
    public GameObject powerUp;

    void Start()
    {
        distance = 30f;

        minEnemy = 2;
        maxEnemy = 5;

        minPower = 1;
        maxPower = 4;

        maxPosEnemy = 21.5f;
        minPosEnemy = 3.27f;

        maxPosPower = 22.02f;
        minPosPower = 3.9f;



        cameraObj = GameObject.Find("Main Camera");
        infiniteObj = GameObject.Find("InfiniteObject");

        randoming = true;

        countingEnemies = 0;
        countingPowers = 0;
    }

    void Update()
    {

        if (cameraObj.GetComponent<CameraScript>().move == true)
        {
            infiniteObj.transform.Translate(new Vector3(cameraObj.GetComponent<CameraScript>().speed, 0, 0) * Time.deltaTime, Space.World);
        }

        if (infiniteObj.transform.position.x >= distance)
        {
            selecting = true;
            infiniteObj.transform.position = new Vector3(0, 0, 0);
        }

        if (selecting == true)
        {
            SelectSpawnObjects();
        }

        if (enemyCount >= enemyNum && powerCount >= powerUpNum)
        {
            countingEnemies = 0;
            countingPowers = 0;

            enemyCount = 0;
            powerCount = 0;

            selecting = false;
            randoming = true;
        }
    }

    void SelectSpawnObjects()
    {
        if (randoming == true)
        {
            enemyNum = Random.Range(minEnemy, maxEnemy);
            powerUpNum = Random.Range(minPower, maxPower);
            Debug.Log("A");
            randoming = false;
        }
        else
        {
            if (countingEnemies < enemyNum)
            {
                enemyObj = Random.Range(1, 5);
                countingEnemies++;
                SpawnEnemies();
            }

            if (countingPowers < powerUpNum)
            {
                SpawnObjects();
                countingPowers++;
            }
        }
    }

    void SpawnObjects()
    {
        YPosPower = Random.Range(minPosPower, maxPosPower);
        XPosPower = Random.Range(cameraObj.transform.position.x + 30f, cameraObj.transform.position.x + 80f);

        Instantiate(powerUp, transform.position = new Vector3(XPosPower, YPosPower, 0), transform.rotation);
        powerCount++;
    }

    void SpawnEnemies()
    {
        YPosEnemy = Random.Range(minPosEnemy, maxPosEnemy);
        XPosEnemy = Random.Range(cameraObj.transform.position.x + 30f, cameraObj.transform.position.x + 80f);

        switch (enemyObj)
        {
            case 1:
                Instantiate(enemy, transform.position = new Vector3(XPosEnemy, YPosEnemy, 0), transform.rotation);
                enemyCount++;
                break;

            case 2:
                Instantiate(car1, transform.position = new Vector3(XPosEnemy, YPosEnemy, 0), transform.rotation);
                enemyCount++;
                break;

            case 3:
                Instantiate(car2, transform.position = new Vector3(XPosEnemy, YPosEnemy, 0), transform.rotation);
                enemyCount++;
                break;

            case 4:
                Instantiate(barrier, transform.position = new Vector3(XPosEnemy, YPosEnemy, 0), transform.rotation);
                enemyCount++;
                break;
        }
    }
}
