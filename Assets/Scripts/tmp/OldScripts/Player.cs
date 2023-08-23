using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Vector3 startTouchPos;
    Vector3 endTouchPos;
    float flickValue_x;
    float flickValue_y;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            startTouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        }
        if (Input.GetMouseButtonUp(0) == true)
        {
            endTouchPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            GetDirection();
        }
    }

    void GetDirection()
    {
        flickValue_x = endTouchPos.x - startTouchPos.x;
        flickValue_y = endTouchPos.y - startTouchPos.y;

        if (Mathf.Abs(flickValue_x) > Mathf.Abs(flickValue_y))
        {
            flickValue_y = 0;
        }
        else
        {
            flickValue_x = 0;
        }

        if (flickValue_x > 300.0f)
        {
            transform.position += new Vector3(200, 0, 0);
        }

        if (flickValue_x < -300.0f)
        {
            transform.position += new Vector3(-200, 0, 0);
        }

        if (flickValue_y > 300.0f)
        {
            transform.position += new Vector3(0, 200, 0);
        }

        if (flickValue_y < -300.0f)
        {
            transform.position += new Vector3(0, -200, 0);
        }
    }

    // void FlickDirection()
    // {
    //     flickValue_x = endTouchPos.x - startTouchPos.x;
    //     flickValue_y = endTouchPos.y - startTouchPos.y;
    //     // Debug.Log("x スワイプ量は" + flickValue_x);
    //     // Debug.Log("y スワイプ量は" + flickValue_y);
    // }
}
