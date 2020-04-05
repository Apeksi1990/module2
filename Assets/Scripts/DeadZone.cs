using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadZone : MonoBehaviour
{

    public GameObject buttonPanel;
    public GameObject buttonResetLevel;
    public GameObject gameOverText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            GameOver(other.gameObject);
        }
    }

    private void GameOver(GameObject player)
    {
        Rigidbody2D rigidbody2D = player.transform.GetComponent<Rigidbody2D>();
        rigidbody2D.Sleep();

        buttonPanel.SetActive(false);
        buttonResetLevel.SetActive(true);
        gameOverText.SetActive(true);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
