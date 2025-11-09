using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSound : MonoBehaviour
{
    public AudioClip coinRecieve;
    private void OnDestroy()
    {
        if (coinRecieve!=null)
        {
            AudioSource.PlayClipAtPoint(coinRecieve, transform.position);
        }
    }
}