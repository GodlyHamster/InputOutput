using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{

    private float _moveDirection;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 0)
        {
            _moveDirection = -1;
        }
        else if (transform.position.x < 0)
        {
            _moveDirection = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(_moveDirection, 0, 0) * moveSpeed * Time.deltaTime;
    }

    public float getSpeed()
    {
        return moveSpeed;
    }

    public void setSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            Destroy(gameObject);
        }
    }
}
