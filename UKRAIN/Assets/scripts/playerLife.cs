using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLife : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    private  void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void Die()
    {
        
       
        anim.SetTrigger("death");
    }
}
