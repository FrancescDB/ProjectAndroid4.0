using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 firstPos;

    public float speed;
    public float meters;
    public bool move;
    public GameObject PauseObj;

    void Start()
    {
        meters = 0f;
        speed = 5f;

        move = false;

        firstPos = this.gameObject.transform.position;
    }

    void Update()
    {
        if (move == true)
        {
            transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime, Space.World);
        }

        meters = -firstPos.x + this.gameObject.transform.position.x;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            move = true;
        }
    }
}
