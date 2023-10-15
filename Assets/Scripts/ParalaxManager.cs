using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxManager : MonoBehaviour
{
    private int movingBackground;
    private float timer;
    private float speed;
    private bool firstMove;
    private Vector3 cameraPos;

    public GameObject backgroundObj1;
    public GameObject backgroundObj2;
    public GameObject paralaxObj;
    public GameObject cameraObj;
    public GameObject rightPoint1;
    public GameObject rightPoint2;

    void Start()
    {
        timer = 0f;
        speed = 5f;
        movingBackground = 1;
        firstMove = true;

        cameraPos = new Vector3(paralaxObj.transform.position.x, paralaxObj.transform.position.y, paralaxObj.transform.position.z);
    }

    void Update()
    {
        if (speed < 9 && cameraObj.GetComponent<CameraScript>().move == true)
        {
            if (timer >= 20f)
            {
                timer = 0f;
                speed = speed + 0.5f;
                cameraObj.GetComponent<CameraScript>().speed = cameraObj.GetComponent<CameraScript>().speed + 0.5f;
            }
            else
            {
                timer = timer + Time.deltaTime;
            }
        }

        paralaxObj.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);

        if (firstMove == true && cameraObj.transform.position.x >= cameraPos.x + 12f)
        {
            backgroundObj2.transform.position = new Vector3(backgroundObj1.transform.position.x + 152.342f, backgroundObj1.transform.position.y, backgroundObj1.transform.position.z);
            paralaxObj.transform.position = new Vector3(backgroundObj1.transform.position.x, 0, 0);
            movingBackground = 2;
            firstMove = false;
        }

        if (firstMove == false)
        {
            if (paralaxObj.transform.position.x >= rightPoint1.transform.position.x)
            {
                switch (movingBackground)
                {
                    case 1:;
                        backgroundObj2.transform.position = rightPoint1.transform.position;
                        DoingTP1();
                        break;

                    case 2:
                        backgroundObj1.transform.position = rightPoint2.transform.position;
                        DoingTP2();
                        break;
                }
            }
        }
    }

    void DoingTP1()
    {
        movingBackground = 2;
        paralaxObj.transform.position = new Vector3(backgroundObj1.transform.position.x, 0, 0);
    }

    void DoingTP2()
    {
        movingBackground = 1;
        paralaxObj.transform.position = new Vector3(backgroundObj1.transform.position.x, 0, 0);
    }
}
