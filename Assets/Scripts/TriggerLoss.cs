using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLoss : MonoBehaviour
{
    float timer = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lose"))
        {
            timer += Time.deltaTime;
            if(timer >= GameManager.instance.TimeTillGameOver)
            {
                GameManager.instance.GameOver();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lose"))
        {
            timer = 0f;
        }
    }
}
