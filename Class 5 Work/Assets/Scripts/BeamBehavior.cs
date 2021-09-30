using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //get rid of beams
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    //when beams are off screen, destroy them
    private void OnBecameInvisible()
    {
       Destroy(gameObject);
    }
}
