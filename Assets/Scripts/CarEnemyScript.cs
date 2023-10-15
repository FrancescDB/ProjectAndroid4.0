using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemyScript : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;
    private GameObject playerObj;
    private GameObject cameraObj;

    void Start()
    {
        speed = 20f;

        rb = GetComponent<Rigidbody>();

        playerObj = GameObject.Find("PlayerParent");
        cameraObj = GameObject.Find("Main Camera");
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, cameraObj.transform.position) <= 80 && Vector3.Distance(transform.position, cameraObj.transform.position) > 50)
        {
            transform.position = new Vector3(transform.position.x, playerObj.transform.position.y, 0);
        }

        if (Vector3.Distance(transform.position, cameraObj.transform.position) <= 50)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        rb.velocity = new Vector3(-speed, 0, 0);

        yield return new WaitForSeconds(4f);

        Destroy(this.gameObject);
    }
}
