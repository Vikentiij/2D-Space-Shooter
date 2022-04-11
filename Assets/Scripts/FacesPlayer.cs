using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacesPlayer : MonoBehaviour
{
    public float rotSpeed = 90f;
    // public Transform player;
     Transform player;
    
    // Update is called once per frame
    void Update()
    {
        if(player == null){
            //find the player ship   GameObject.FindWithTag() or
          GameObject go = GameObject.FindWithTag("Player");
           if (go != null){
             player = go.transform;
            }
        }
        //at this point, we've found player or 
        // it doesnot exist right now
        if(player == null)
        return;  //try again next frame

        // Here-- we know for sure we have a player. Turn to face it
        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
      //  transform.rotation= Quaternion.Euler( 0, 0,zAngle); 
      Quaternion desiredRot = Quaternion.Euler( 0, 0,zAngle);
      transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed* Time.deltaTime);
    }
}
