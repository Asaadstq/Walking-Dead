using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshscript : MonoBehaviour
{

    NavMeshAgent agent;
    public Animator anim;
    [SerializeField] Transform Player;
    // Start is called before the first frame update
    void Start()
    {
         anim.SetBool("Idle",true);
        
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
Startmoving();
       
    }
    

    public void Startmoving(){
         agent.autoRepath=true;
        agent.SetDestination(Player.position);



    }
}
