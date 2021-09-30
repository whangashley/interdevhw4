using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject beam;
    public float shootSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject newBeam = Instantiate(beam, transform.position, transform.rotation);
            //childs beam to the player within the hierarchy. Parent and transform go together
            newBeam.transform.SetParent(gameObject.transform);
            //set beam's location so that it is relative to the player's location
            newBeam.transform.localPosition = new Vector3(0.7f, -0.3f);
            //force for the beam
            newBeam.GetComponent<Rigidbody2D>().velocity = Vector2.right * shootSpeed;

            //facing right
            float dir = 0f;
            if (PlayerMove.faceRight)
            {
                dir = 1f;
            }
            else
            {
                //flip sprite
                newBeam.GetComponent<SpriteRenderer>().flipX = true;
                //opposite direction
                dir = -1f;
            }

            newBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(dir * shootSpeed, 0f);

        }
    }
}
