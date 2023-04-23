using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    public Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = _camera.ScreenToWorldPoint(Input.mousePosition);

        mouse = new Vector3(mouse.x, mouse.y);

        transform.position = mouse;
    }
}
