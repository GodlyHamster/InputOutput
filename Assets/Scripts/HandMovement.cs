using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class HandMovement : MonoBehaviour
{

    enum ControlSelection
    {
        Leap,
        Keys
    };

    [SerializeField] ControlSelection Controller = ControlSelection.Leap;

    [SerializeField] private GameObject[] _Hands;

    Controller controller;

    void Start()
    {
        controller = new Controller();
    }

    void Update()
    {
        if (Controller == ControlSelection.Leap)
        {
            UsingLeap();
        }else if(Controller == ControlSelection.Keys)
        {
            UsingKeys();
        }
    }

    void UsingKeys()
    {
        float rH = Input.GetAxis("RightHand");
        float lH = Input.GetAxis("LeftHand");

        KeySetHandPos(0, lH);
        KeySetHandPos(1, rH);
    }
    void KeySetHandPos(int hand, float height)
    {
        float xOffset = 0;

        if (hand == 0) { xOffset = -3; }
        else if (hand == 1) { xOffset = 3; }

        _Hands[hand].transform.position = new Vector3(xOffset, height * 3, 0);
    }

    void UsingLeap()
    {
        List<Hand> hands;
        Hand leftHand = null;
        Hand rightHand = null;

        Frame frame = controller.Frame();
        if (frame.Hands.Count > 0)
        {
            hands = frame.Hands;
            if (hands[0].IsLeft)
            {
                leftHand = hands[0];
            }
            else if (hands[0].IsRight)
            {
                rightHand = hands[0];
            }

            if (frame.Hands.Count > 1)
            {
                if (hands[1].IsLeft)
                {
                    leftHand = hands[1];
                }
                else if (hands[1].IsRight)
                {
                    rightHand = hands[1];
                }
            }

            if (leftHand != null)
            {
                LeapSetHandPos(leftHand);
            }
            if (rightHand != null)
            {
                LeapSetHandPos(rightHand);
            }
        }
    }

    void LeapSetHandPos(Hand h)
    {
        int handUsed = 0;
        float offset = 0;

        if (h.IsLeft)
        {
            handUsed = 0;
            offset = -3;
        }
        else if (h.IsRight)
        {
            handUsed = 1;
            offset = 3;
        }

        if (h.PalmPosition.z <= -50)
        {
            _Hands[handUsed].transform.position = new Vector3(offset, 3, 0);
        }
        else if (h.PalmPosition.z >= 50)
        {
            _Hands[handUsed].transform.position = new Vector3(offset, -3, 0);
        }
        else
        {
            _Hands[handUsed].transform.position = new Vector3(offset, 0, 0);
        }
    }
}
