using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float health = 2f;
    private float _startinghealth;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    private float _speedboost = 1;

    public int lives = 3;

    private bool TripleShot = false;
    [SerializeField]
    private bool _shieldActive = false;

    [SerializeField]
    private GameObject _shield;
    

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleshotPrefab;

    private SpawnManager _spawnManager;

    void Start()
    {
        _startinghealth = health;
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
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
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Fire3 is shift
        float sprintInput = Input.GetAxis("Fire3") * 2 + 1;
        float speedPlayer = speed * sprintInput * Time.deltaTime *_speedboost;

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
        _canFire = Time.time + _fireRate;
        if (TripleShot == true)
        {
            Instantiate(_tripleshotPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }

        else {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Damage();
        }
    }

    public void Damage ()
    {
        if (_shieldActive == true) {
            _shieldActive = false;
            return;
        }

        health--;
        Debug.Log("OUCH");
        if (health <= 0)
        {
            respawn();
        }
    }

    public void activateTripleShot()
    {
        TripleShot = true;
        StartCoroutine(TripleShotCooldown());
    }

    IEnumerator TripleShotCooldown()
    {
        yield return new WaitForSeconds(5);
        TripleShot = false;
    }

    private void respawn()
    {
        lives--;
        if (lives > 0)
        {
            health = _startinghealth;
            transform.position = new Vector3(0, 0, 0);
        }

        else {
            Destroy(gameObject);
            _spawnManager.OnPlayerDeath();

        }

    }

    public void activateSpeedBoost()
    {
        Debug.Log("Collected Speed Boost");
        _speedboost = 2;
        StartCoroutine(SpeedBoostCooldown());

    }

    IEnumerator SpeedBoostCooldown()
    {
        yield return new WaitForSeconds(5);
        _speedboost = 1;
        Debug.Log("speed boost ended");
    }

    public void activateShield()
    {
        _shieldActive = true;
        Debug.Log("Collected Shield");
        StartCoroutine(ShieldCooldown());
        _shield.SetActive(true);
    }

    IEnumerator ShieldCooldown()
    {
        yield return new WaitForSeconds(5);
        _shieldActive = false;
        Debug.Log("shield ended");
        _shield.SetActive(false);
    }



}

