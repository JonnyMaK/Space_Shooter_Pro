using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour


{
    [SerializeField]
    private float _speed = 3;
    [SerializeField]
    private int powerupID; //0=tripleshot 1=speedBoost 2=Shield

    

    void Update()
    {
        CalculateMovement();
        if (transform.position.y <= -4f)
        {
            Destroy(gameObject);
        }
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(gameObject);

        Player player = other.transform.GetComponent<Player>();

        if (player != null)
        {
            switch (powerupID)
            {
                case 0:
                    player.activateTripleShot();
                    break;
                case 1:
                    player.activateSpeedBoost();
                    break;
                case 2:
                    player.activateShield();
                    break;
                default:
                    Debug.Log("Default Value");
                    break;
            }
        }




    }

}
