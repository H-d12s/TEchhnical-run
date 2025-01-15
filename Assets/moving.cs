using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour

{
     private Rigidbody2D rb; //private means that only this script can access this variable not any other codes
    // Start is called before the first frame update
    private Animator anim;
    private SpriteRenderer sprite;
    private float dirx=0f;
    [SerializeField]private float movespeed=7f;
    [SerializeField]private float jumpforce=14f;
    private enum  movementstate{idle,running,jumping,faling};
    private BoxCollider2D coll;
    [SerializeField]private LayerMask jumpableground;

    // Start is called before the first frame update
    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
        coll= GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
      dirx=Input.GetAxisRaw("Horizontal");
        //getaxis immediately sets the value to 0 as soon as we relasese left or right 
        rb.velocity =new Vector2(dirx*movespeed,rb.velocity.y);
        // basically bollo if dirx=-1 then it will move in -x direction and vice versa
         // y =0 na hoar karon jump r forward ekshate press korle egobe na tai rb.velocity.y dilo jate ekta value thake
         if (Input.GetButtonDown("Jump")&& isgrounded())
        {
            rb.velocity=new Vector2(rb.velocity.x,jumpforce);
        }
        animup();
    }
 private void animup()
    { movementstate state;
         if (dirx>0f)
        {
            state=movementstate.running;
            sprite.flipX=false;
            }
        else if(dirx<0f)
        {
            state=movementstate.running;
            sprite.flipX=true;
            }
        else
        {
         state=movementstate.idle;
        }
        if (rb.velocity.y>.1f)
        {
            state=movementstate.jumping;
        }
        else if (rb.velocity.y<-.1f)
        {
            state=movementstate.faling;
        }
        anim.SetInteger("state",(int)state);
    }
    private bool isgrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,.1f,jumpableground);
    }
}
