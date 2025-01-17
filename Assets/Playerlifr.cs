using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerlifr : MonoBehaviour
{private Animator anim;
private Rigidbody2D rb;
    // Start is called before the first frame update
  private void Start()
    {
        anim = GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("traps"))
        {
            Die();
        }
    }
    private void Die()
    {
        rb.bodyType=RigidbodyType2D.Static;
        anim.SetTrigger("death");
    

    }
    private void restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
