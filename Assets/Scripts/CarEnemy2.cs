using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemy2 : MonoBehaviour
{
    private float speed;
    private Rigidbody rb;
    private GameObject cameraObj;

    void Start()
    {
        speed = 20f;

        rb = GetComponent<Rigidbody>();
        cameraObj = GameObject.Find("Main Camera");
    }

    void Update()
    {
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
