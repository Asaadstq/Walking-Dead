using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float health= 1f;
    public Slider slider;
    public Canvas canvas;
    //public float sldervalue;


    public void TakeDamage(float amount ){
        Debug.Log("in");
        health-=amount;
        slider.value=health;
        
die();

    }
    // Start is called before the first frame update
void die(){

    if (health<=0f){
        
        Destroy(canvas);
        Destroy(gameObject);
    }
}

}
