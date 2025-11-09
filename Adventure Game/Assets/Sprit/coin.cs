using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coin : MonoBehaviour
{
    [SerializeField] private float goldCoin;
    [SerializeField] private float silverCoin;
    [SerializeField] private float bronzeCoin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("goldCoin"))
        {
            goldCoin = 1;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("silverCoin"))
        {
            silverCoin = 1;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("bronzeCoin"))
        {
            bronzeCoin = 1;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("win")&&goldCoin==1f&&bronzeCoin==1f&&silverCoin==1f)
        {
            SceneManager.LoadScene(2);
        }
    }
}
