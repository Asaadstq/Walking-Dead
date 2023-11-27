//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RaycastShooting : MonoBehaviour


{
    public TextMeshProUGUI text;
   public float damage;
   public float range;
   public GameObject place ;
   //public ParticleSystem fire;
   //public GameObject light;

   void Start(){


    
   }
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            //text.text
            Shoot();
            
            //fire.Play();
            //light.
        }
    }

    public void Shoot(){

RaycastHit hit;


if(Physics.Raycast(place.transform.position,place.transform.forward,out hit,range)){

    //Debug.Log(hit.transform.name);
    Enemy enemy = hit.transform.GetComponent<Enemy>();
    if(enemy!=null){
        Debug.Log("hitten");
        enemy.TakeDamage(damage);
    }
}

    }
}
