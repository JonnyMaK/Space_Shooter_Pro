using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    private Vector3 _centerTurretVector = new Vector3(0, 0.8f, 0);
    public float health = 2f;
    public int lives = 3;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void CalculateMovement()
    {
        //declare variables
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //Fire3 is shift
        float sprintInput = Input.GetAxis("Fire3") * 2 + 1;
        float speedPlayer = speed * sprintInput * Time.deltaTime;

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speedPlayer);

        //MathF.clamp clamps code between 2 values
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0f), transform.position.z);

        //wraparound
        if (transform.position.x >= 11.3)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x <= -11.3)
        {
            transform.position = new Vector3(11.3f, transform.position.y, transform.position.z);
        }
    }

    void FireLaser()
    {
        Instantiate(_laserPrefab, transform.position + _centerTurretVector, Quaternion.identity);
        _canFire = Time.time + _fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.tag);
        if (other.tag == "Enemy")
        {
            Damage();

        }
    }

    public void Damage ()
    {
        Debug.Log(health);
        health --;

        if (health <= 0)
        {
            respawn();
        }
    }

    private void respawn()
    {
        lives--;
        if (lives > 0)
        {
            health = 2;
            transform.position = new Vector3(0, 0, 0);
        }

        else {
            Destroy(gameObject);
        }

    }
}

