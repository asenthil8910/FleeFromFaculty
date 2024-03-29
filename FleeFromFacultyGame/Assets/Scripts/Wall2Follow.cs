using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall2Follow : MonoBehaviour{

public Transform target;
public float stoppingDistance = 0.1f;
public float speed = 5f;
private Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        
        // disable Raycasts, so mouse will not click
        gameObject.layer = 2;
    }


    void FixedUpdate(){
        Vector3 targetPos = target.position;
        Vector3 currentPos = transform.position;

        float distance = Vector3.Distance(currentPos, targetPos);

        if (distance > stoppingDistance){
            Vector3 directionOfTravel = targetPos - currentPos;
            directionOfTravel.Normalize();
            rb.MovePosition(currentPos + (directionOfTravel * speed * Time.deltaTime));
        }

    }

    public void OnCollisionEnter2D(Collision2D other){
        //set velocity to zero on cllsions, so wall does not vibrate
        //rb.velocity = new Vector2(0,0);
        rb.velocity = Vector2.zero;
    }

    /*
    void OnMouseEnter(){
        gameObject.GetComponent<BoxCollider2D>().enabled=false;
        if (Input.GetMouseButtonDown (0)) {
            gameObject.GetComponent<BoxCollider2D>().enabled=true;
        }
    }

    void OnMouseExit(){
        gameObject.GetComponent<BoxCollider2D>().enabled=true;
    }
    */

}

//NOTE: Put this on the actual wall object. Should have a Rigidbody2D and a BoxCollider2D.