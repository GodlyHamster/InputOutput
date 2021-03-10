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
        Frame frame = controller.Frame();
        // do something with the tracking data in the frame...
        Hand hand1 = new Hand();
        Leap.Vector handpos = hand1.PalmPosition;
        Debug.Log(handpos);
    }
}
