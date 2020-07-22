using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
   
{
    [SerializeField]
    private float _speed=1f;
    [SerializeField]
    private GameObject _container;

    void Start()
    {
        _container = GameObject.Find("Projectile Container");
        gameObject.transform.parent = _container.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y >= 9f)
        {
            Destroy();
        }
    }

   void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        Destroy(gameObject);
    }

}

