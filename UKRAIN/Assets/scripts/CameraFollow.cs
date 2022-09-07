using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    float speed = 3f;
    public Vector3 offset;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position =new Vector3(target.position.x, target.position.y, target.position.z);

    }
    private void Update()
    {
       Vector3 position =target.position + offset;
        
       

        transform.position = Vector3.Lerp(transform.position, position, speed *Time.deltaTime);
    }
   
}
