using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    private Rigidbody2D rb; //private means that only this script can access this variable not any other codes
    // Start is called before the first frame update
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirx=0f;
    [SerializeField]private float movespeed=7f;
    [SerializeField]private float jumpforce=14f;
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirx=Input.GetAxisRaw("Horizontal");
        //getaxis immediately sets the value to 0 as soon as we relasese left or right 
        rb.velocity =new Vector2(dirx*movespeed,rb.velocity.y);
        // basically bollo if dirx=-1 then it will move in -x direction and vice versa
         // y =0 na hoar karon jump r forward ekshate press korle egobe na tai rb.velocity.y dilo jate ekta value thake
         if (Input.GetButtonDown("Jump"))
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpforce);
        }
        animup();
    }
    private void animup()
    {
         if (dirx>0f)
        {
            anim.SetBool("running",true);
            sprite.flipX=false;
            }
        else if(dirx<0f)
        {
            anim.SetBool("running",true);
            sprite.flipX=true;
            }
        else
        {
         anim.SetBool("running",false);
        }
    }
}