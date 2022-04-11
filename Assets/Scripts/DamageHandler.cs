using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
   // void OnCollisionEnter2D() {
     //   Debug.Log ("Collision");
        
   // }
   public  int health = 2;
   public float invulnPeriod = 0;
   float invulnTimer = 0;
   int correctLayer;
   //float invulnAnimTimer = 0;
   SpriteRenderer spriteRend;

    void Start() {
       correctLayer = gameObject.layer;
       // Note this only get the render on the parent object
       // it doesnot work for children for ex "enemy01"
       spriteRend = GetComponent<SpriteRenderer>();
       if(spriteRend == null){
           spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

           if(spriteRend==null){
             Debug.LogError("Object '"+gameObject.name+"' has no sprite render");
             }
       }
   }
    void OnTriggerEnter2D() {
        Debug.Log ("Trigger");
        health --;
        if(invulnPeriod > 0){
        invulnTimer = invulnPeriod;
        gameObject.layer = 10;
        }
    }
    void Update() {
        if(invulnTimer > 0){
        invulnTimer = invulnTimer - Time.deltaTime;

            if (invulnTimer<= 0){
              gameObject.layer = correctLayer;
              if(spriteRend != null){
                  spriteRend.enabled =true;
              }
            }
            else{
                if(spriteRend != null){    //invulnAnimTimer ==0
                    spriteRend.enabled = !spriteRend.enabled;
                }
            }
        }

      if(health <= 0){
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
        
    }

    



}
