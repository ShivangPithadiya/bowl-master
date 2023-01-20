using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swiper : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
