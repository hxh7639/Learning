using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

    private Animator anim;


    void Start () {
        anim = GetComponent<Animator>();
     }

    void OnTriggerStay2D(Collider2D collider){
        GameObject obj = collider.gameObject;

        // leave the method if not colliding with defender
        if (obj.GetComponent<Attacker>())
        {
            anim.SetTrigger("underAttack Trigger");
        }
    }


}
