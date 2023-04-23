using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//los objetos pueden ser mencionados en variables como GameObject
public class FollowPlayer : MonoBehaviour
{

    public GameObject Player;

    public Vector3 offset= new Vector3(0,5,-8);
    // Update is called once per frame
    void Update()
    {
        this.transform.position = Player.transform.position + offset ;

    }
}
