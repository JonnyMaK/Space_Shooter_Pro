using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
   
{
    [SerializeField]
    private float _speed=1f;
    private UIManager _UIManager;

    private void Start()
    {
        _UIManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_UIManager == null)
        {
            Debug.LogError("The UIManager is Null");
        }
    }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy();
            _UIManager.ScoreUpdate(1);
        }
    }

    void Destroy()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        Destroy(gameObject);
        
    }
}

