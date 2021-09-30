using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float gravityMultiplier;

    bool onFloor;

    Rigidbody2D myBody;

    SpriteRenderer myRenderer;

    public Sprite jumpSprite;
    public Sprite walkSprite;

    public static bool faceRight = true;

    //WALK ANIMATION
    //public Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        //same as dragging into inspector but in code!
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onFloor && myBody.velocity.y > 0)
        {
            onFloor = false;
        }
        CheckKeys();
        JumpPhysics();

        //WALK ANIMATION
        /*
        if(myBody.velocity.x < 0.1f && myBody.velocity.x > -0.1f)
        {
            myAnim.SetBool("isWalking", false);
        }
        */
    }

    void CheckKeys()
    {
        if (Input.GetKey(KeyCode.D))
        {
            faceRight = true;
            //flip walking sprite
            myRenderer.flipX = false;

            //WALK ANIMATION
            /*
            if (onFloor)
            {
                myAnim.SetBool("isWalking", true);
            }*/


            //myBody.velocity = new Vector3(speed, myBody.velocity.y);
            HandleLRMovement(speed);
        }
            else if (Input.GetKey(KeyCode.A))
            {
            faceRight = false;
            //flip walking sprite
            myRenderer.flipX = true;

            //WALK ANIMATION
            /*
            if (onFloor)
            {
                myAnim.SetBool("isWalking", true);
            }*/

            //myBody.velocity = new Vector3(-speed, myBody.velocity.y);
            HandleLRMovement(-speed);
            }

        if (Input.GetKey(KeyCode.W) && onFloor)
        {
            //if jumping, change the sprite to jumpsprite
            myRenderer.sprite = jumpSprite;
            myBody.velocity = new Vector3(myBody.velocity.x, jumpHeight);
        }

            //if W is not currently pressed and the player is not on the platform
            else if (!Input.GetKey(KeyCode.W) && !onFloor)
            {
                //give boost using gravity when we go up
                myBody.velocity += Vector2.up * Physics2D.gravity.y * (jumpHeight - 1f) * Time.deltaTime;
            }
    }

    void JumpPhysics()
    {
        //if player is going down
        if(myBody.velocity.y < 0)
        {
            //gravity pushes down more when jumping down/landing
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (gravityMultiplier - 1f) * Time.deltaTime;
        }
    }

    void HandleLRMovement(float dir)
    {
        myBody.velocity = new Vector3(dir, myBody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            myRenderer.sprite = walkSprite;
            onFloor = true;
        }
        //if player collides with object with enemy tag
        if (collision.gameObject.tag == "enemy")
        {
            //destroy player (me = gameObject)
            Destroy(gameObject);
        }
    }

}
