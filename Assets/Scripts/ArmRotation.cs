using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    private float rotationPos;
    private Vector2 rotationAngle;

    public GameObject playerObj;
    public GameObject armObj;

    void Update()
    {
        rotationAngle = playerObj.GetComponent<PlayerController>().inputShooting;

        if (rotationAngle == new Vector2(0, 0))
        {
            if (playerObj.GetComponent<PlayerController>().lookingRight == true)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }
        else
        {
            rotationPos = Mathf.Atan2(rotationAngle.x, rotationAngle.y) * Mathf.Rad2Deg;

            if (playerObj.GetComponent<PlayerController>().lookingRight == true)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -rotationPos + 90f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 180f, rotationPos + 90f);
            }
        }
    }
}
