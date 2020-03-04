using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeColliderScript : MonoBehaviour
{
    public string currentScene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Magnet"))
        {
            SceneManager.LoadScene(currentScene);
        }
    }
}
