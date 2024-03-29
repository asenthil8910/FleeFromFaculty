using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall1Dragger : MonoBehaviour{
    private bool selected;
    public GameObject targetWall;

    public bool isVertical = true;

    void Update () {
        if (selected == true) {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            //transform.position = new Vector2 (cursorPos.x, cursorPos.y);

            
            if (isVertical){
                // Move along x-axis
                transform.position = new Vector2 (transform.position.x, cursorPos.y);
            }
            else{
                // Move along y-axis
                transform.position = new Vector2 (cursorPos.x, transform.position.y);
            }
            
        }

        if (Input.GetMouseButtonUp (0)) {
            selected = false;
            targetWall.GetComponent<Rigidbody2D>().mass = 1f;
            transform.position = targetWall.transform.position;
        }
    }

    void OnMouseOver(){
        if (Input.GetMouseButtonDown (0)) {
            selected = true;
            targetWall.GetComponent<Rigidbody2D>().mass=0.00001f;
        }
    }
}
