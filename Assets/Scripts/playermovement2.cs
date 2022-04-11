using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement2 : MonoBehaviour
{
    float maxSpeed = 5f;
    float rotSpeed = 180f;

    float shipBoundaryRadius = 0.5f;
    void Start()
    {
        
    }

    
    void Update()
    {
        //rotate the ship
// transform.Rotate();   angle
       // grab our rotation quaternion
       Quaternion rot = transform.rotation;
       //grab the z euler angle
       float z = rot.eulerAngles.z; 
       //change the z angle based on input
       z= z - Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
       //recreate the quaternion
       rot= Quaternion.Euler(0,0,z);
       //feed the quaternion into our rotation
       transform.rotation = rot;


        // move the ship
      //  pos.y= pos.y + Input.GetAxis("Vertical");
    //  transform.Translate(new Vector3(0,Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime,0));
    
    Vector3 pos=transform.position;

    Vector3  velocity= new Vector3(0,Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime,0);
     //  pos.y = pos.y + Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
     //  pos.x = pos.x + Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
     pos = pos + rot*velocity;

    // restrict the player to the camera's boundaries

    // first to vertical, because its simpler
    if(pos.y + shipBoundaryRadius > Camera.main.orthographicSize) {
       pos.y = Camera.main.orthographicSize - shipBoundaryRadius; 
    }

    if(pos.y - shipBoundaryRadius < -Camera.main.orthographicSize) {
       pos.y = -Camera.main.orthographicSize + shipBoundaryRadius; 
    }
   // calculate the orthographic width based on the screen ratio
    float screenRatio = (float)Screen.width / (float)Screen.height;  // can be weird
    float widthOrtho = Camera.main.orthographicSize *screenRatio;  
   // horisontal bounds
if(pos.x + shipBoundaryRadius > widthOrtho) {
       pos.x = widthOrtho - shipBoundaryRadius; 
    }

    if(pos.x - shipBoundaryRadius < -widthOrtho) {
       pos.x = -widthOrtho + shipBoundaryRadius; 
    }
    // update our position
        transform.position = pos;



    }
}
