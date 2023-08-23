using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButtonManager : MonoBehaviour
{
    public SetManager set;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PushPlayerButton()
    {
        set.ReturnDraggingImage(set.bottomGameImage.transform.childCount + 1, gameObject.transform);
    }
}
