using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float moveSpeed;

    private void Update()
    {
        transform.position += Vector3.right * moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestroyCar"))
        {
            Debug.Log("부딪혔나?");
            Destroy(gameObject);
        }
    }
}
