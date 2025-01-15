using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class stickyplatform : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
   {
    if (collision.gameObject.name=="playur")
    {
        collision.gameObject.transform.SetParent(transform);

    }
   }
private void OnCollisionExit2D(Collision2D collision)
{
     if (collision.gameObject.name=="playur")
    {
        collision.gameObject.transform.SetParent(null);

    }

}
}
