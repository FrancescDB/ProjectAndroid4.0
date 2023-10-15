using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float shotTime;
    private float speed;
    private float laserOffset;
    private bool moving;
    private bool canShoot;
    private Rigidbody rb;
    private AudioSource shoot;

    public int points;
    public int powerupCount;
    public int powerupState;
    public int life;
    public bool lookingRight;
    public Vector2 inputMovement;
    public Vector2 inputShooting;
    public GameObject laserPointObj;
    public GameObject deathMenu;
    public GameObject ui;
    public GameObject pauseMenu;

    void Start()
    {
        life = 5;
        powerupState = 0;

        laserOffset = 0.1f;
        shotTime = 5f;
        speed = 10f;
        moving = false;
        canShoot = true;
        lookingRight = true;

        rb = GetComponent<Rigidbody>();
        shoot = GetComponent<AudioSource>();

        Application.targetFrameRate = 60;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();

        moving = true;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        inputShooting = context.ReadValue<Vector2>();
    }

    void Update()
    {
        if (inputMovement == new Vector2(0, 0))
        {
            moving = false;
        }

        if (inputShooting.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            lookingRight = false;
        }

        if (inputShooting.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            lookingRight = true;
        }

        if (canShoot == true)
        {
            switch (powerupState)
            {
                case 0:
                    shotTime = 0.5f;
                    break;

                case 1:
                    shotTime = 0.4f;
                    break;

                case 2:
                    shotTime = 0.3f;
                    break;

                case 3:
                    shotTime = 0.2f;
                    break;

                case 4:
                    shotTime = 0.1f;
                    break;

                case 5:
                    shotTime = 0.1f;
                    break;
            }

            StartCoroutine(Shooting());
        }
    }

    void FixedUpdate()
    {
        if (moving == true)
        {
            rb.velocity = new Vector3(inputMovement.x * speed, inputMovement.y * speed, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Enemy")
        {
            GetDamage();
        }
    }

    public void GetDamage()
    {
        life--;
        powerupCount = 0;

        if (powerupState > 0)
        {
            powerupState--;
        }

        if (life <= 0)
        {
            deathMenu.SetActive(true);
            ui.SetActive(false);
            pauseMenu.SetActive(false);
            Time.timeScale = 0f;
            Debug.Log("A");
        }
    }

    public void OutOfCamera()
    {
        life = 0;

        GetDamage();
    }

    IEnumerator Shooting()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotTime);
        GameObject laser = LaserScript.Instance.RequestLaser();
        if (lookingRight == true)
        {
            laser.transform.position = laserPointObj.transform.position + new Vector3(inputShooting.x, inputShooting.y, 0) * laserOffset;
        }
        else
        {
            laser.transform.position = laserPointObj.transform.position + new Vector3(inputShooting.x, inputShooting.y, 0) * laserOffset;
        }

        canShoot = true;

        shoot.Play();
    }
}
