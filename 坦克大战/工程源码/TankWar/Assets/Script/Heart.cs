using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Sprite brokenHeart;
    public GameObject explosionEffect;
    private SpriteRenderer sp;



    void Start()
    {
        sp = GetComponent<SpriteRenderer>();

    }

    private void Die()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        sp.sprite = brokenHeart;
    }


}
