using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    
    public NavMeshAgent agent;
    private Transform player;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(findPath());
        StartCoroutine(playerDetect());
    }

    IEnumerator playerDetect()
    {
        while(true)
        {
            if (player == null)
                break;
            if (Vector3.Distance(transform.position, player.position) < 1f)
            {
                animator.SetBool("attack", true);
                player.SendMessage("damage");

            }
            else 
            {
                animator.SetBool("attack", false);
            }
            yield return new WaitForSeconds(.3f);
        }
    }
   
    IEnumerator findPath()
    {
        while(true)
        {
            if (player != null)
            {
                agent.SetDestination(player.position);
                yield return new WaitForSeconds(2f);
            }
            else break;
        }
    }

    public void damage()
    {
        StopAllCoroutines();
        agent.enabled = false;
        animator.SetTrigger("die");
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        Destroy(gameObject, 5f);
        GameManager.instance.deadunit(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
        
    }
}
