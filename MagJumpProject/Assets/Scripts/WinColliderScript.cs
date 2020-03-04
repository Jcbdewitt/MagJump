using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinColliderScript : MonoBehaviour
{
    public string NameOfNextScene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Magnet"))
        {
            SceneManager.LoadScene(NameOfNextScene);
        }
    }
}

