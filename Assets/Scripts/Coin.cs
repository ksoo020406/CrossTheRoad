using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.coinCount += 1;
            //Debug.Log(GameManager.Instance.coinCount);
            Destroy(gameObject);
        }
    }
}
