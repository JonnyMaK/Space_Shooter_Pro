using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float randx;
    public float Speed = 1f;
    Animator _animation;
    private bool _dying = false;

        private void Start()
    {
        _animation = gameObject.GetComponent<Animator>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Laser" && _dying == false)
        {
            //_animation.SetTrigger("Death");
            //Destroy(gameObject);
            StartCoroutine(Death());
            
        }

        if (other.tag == "Player" && _dying == false)
        {
            Player player = other.transform.GetComponent<Player>();
            StartCoroutine(Death());

            if (player != null)
            {
                player.Damage();
            }
        }
    }

    IEnumerator Death ()
    {
        _dying = true;
        _animation.SetTrigger("Death");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
