using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rg;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        rg.velocity = new Vector2(inputX*speed, 0);

        if(inputX > 0)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0,0,0);
        }else if (inputX < 0) 
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else 
        {
            anim.SetBool("walk", false);
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            rg.AddForce(new Vector2(0f, jumpForce));
            anim.SetBool("jump", true);
        }
    }
}
