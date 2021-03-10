using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;

public class HandMovement : MonoBehaviour
{

    [SerializeField] private GameObject[] _Hands;

    Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
    }

    // Update is called once per frame
    void Update()
    {
        List<Hand> hands;
        Hand leftHand = null;
        Hand rightHand = null;

        Frame frame = controller.Frame(); // controller is a Controller object
        if (frame.Hands.Count > 0)
        {
            hands = frame.Hands;
            if (hands[0].IsLeft)
            {
                leftHand = hands[0];
            }else if (hands[0].IsRight)
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
                CheckHandPos(leftHand);
            }
            if (rightHand != null)
            {
                CheckHandPos(rightHand);
            }

        }
        

        void CheckHandPos(Hand h)
        {
            int handUsed = 0;
            float offset = 0;

            if (h.IsLeft)
            {
                handUsed = 0;
                offset = -3;
            }else if (h.IsRight)
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
}
