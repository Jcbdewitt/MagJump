using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Magnet"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Pegs.Add(this.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Magnet"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Pegs.Remove(this.gameObject);
        }
    }
}
