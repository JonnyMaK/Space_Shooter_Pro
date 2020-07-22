using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour


{
    [SerializeField]
    private float _speed = 3;
    

    

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if (transform.position.y <= -5.2f)
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
            player.StartCoroutine(activateTripleShot());
        }

    }
}
