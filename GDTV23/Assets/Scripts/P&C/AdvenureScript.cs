using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Vector3 mousePos;
    public Camera mainCam;
    public Vector3 mouseWorld;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            print("Maustaste wude gedrückt.");

            mousePos = Input.mousePosition;

            print("Screen = " + mousePos);

            mouseWorld = mainCam.ScreenToWorldPoint(mousePos);

            print("World = " + mouseWorld);
        }
    }
}
