using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float randx;
    public float Speed = 1f;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        CalculateMovement();

        if (transform.position.y <= -5.2f)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        randx = Random.Range(-9, 9);
        transform.position = new Vector3(randx, 6.5f, 0);
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
        }
    }
}
