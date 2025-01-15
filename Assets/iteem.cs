using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class iteem : MonoBehaviour
{   private int cherry=0;
[SerializeField]private Text cherriestext;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cherry"))
        {
            Destroy(collision.gameObject);
            cherry++;
            cherriestext.text="Cherries:" + cherry;
        }

    }

    }
