using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{

    [SerializeField] private GameObject[] _Hands;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float LeftMovement = Input.GetAxis("LeftHand");
        float RightMovement = Input.GetAxis("RightHand");
        _Hands[0].transform.position = new Vector3(-3,3*LeftMovement,0);
        _Hands[1].transform.position = new Vector3(3, 3 * RightMovement, 0);
    }
}
