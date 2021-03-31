using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    private float _moveDirection;
    [SerializeField] private float moveSpeed;

    HealthSystem _healthSystem;
    
    void Start()
    {
        _healthSystem = GameObject.Find("LevelController").GetComponent<HealthSystem>();

        if (transform.position.x > 0)
        {
            _moveDirection = -1;
        }
        else if (transform.position.x < 0)
        {
            _moveDirection = 1;
        }
    }

    void Update()
    {
        transform.position += new Vector3(_moveDirection, 0, 0) * moveSpeed * Time.deltaTime;

        if (transform.position.x > 0 && _moveDirection == 1)
        {
            _healthSystem.TakeDamage(10);
            Destroy(gameObject);
        }
        if (transform.position.x < 0 && _moveDirection == -1)
        {
            _healthSystem.TakeDamage(10);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            _healthSystem.AddHealth(1);
            Destroy(gameObject);
        }
    }
    
    public float getSpeed()
    {
        return moveSpeed;
    }

    public void setSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }
}
