using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class born : MonoBehaviour
{
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {   

        Invoke("bornPlayer", 1f);
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void bornPlayer()
    {
        Instantiate(player, transform.position, transform.rotation);
    }
}
