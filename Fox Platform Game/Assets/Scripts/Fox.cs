using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rg;
    private Animator anim;
    public bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //move
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
        else if (inputX == 0)
        {
            anim.SetBool("walk", false);
        }

    //jump
        if(Input.GetKey(KeyCode.Space) && grounded) {
            rg.AddForce(transform.up * speed, ForceMode2D.Impulse);
            anim.SetBool("jump", true);
        }else {
            anim.SetBool("jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        grounded = false;
    }
}
