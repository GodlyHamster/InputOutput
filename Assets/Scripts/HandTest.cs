using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class HandTest : MonoBehaviour
{
    Controller controller;

    void Start()
    {
        controller = new Controller();
    }

    void Update()
    {
        Frame frame = controller.Frame(); // controller is a Controller object
        if (frame.Hands.Count > 0)
        {
            List<Hand> hands = frame.Hands;
            Hand firstHand = hands[0];
            Debug.Log(firstHand.PalmPosition.z);
        }
        else
        {
            Debug.Log("Hand not detectedddddd");
        }
    }
}
