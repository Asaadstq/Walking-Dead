//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RaycastShooting : MonoBehaviour


{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public TextMeshProUGUI text;
   public float damage;
   public float range;
   public GameObject place ;
   public int amination;
   public int mag;
   public Animator anim;
   //public ParticleSystem fire;
   //public GameObject light;
void reloading()
{
    mag -= 30;
    amination = 30;
}
   void Start(){
text.text = $"{amination} / {mag}"; 
    
   }
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            audioSource.PlayOneShot(audioClip);
            anim.SetBool("Hit",true);

            //text.text
            Shoot();
            
            //fire.Play();
            //light.
        }
        else{
           anim.SetBool("Hit",false); 
        }
    }

    public void Shoot(){
        if(amination == 0 && mag == 0)
        return;
        if(amination <= 0)
        {
            reloading();
            return;
        }
        amination--;
text.text = $"{amination} / {mag}";
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
