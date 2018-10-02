using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageble {
    [SerializeField]
    private GameObject _diamondPreFab;
    public int Health { get; set; }

    public override void Initializer()
    {
        base.Initializer();
        base.health = 5;
        Health = base.health;
        base.gems = 4;
    }

    public override void Movement()
    {
        base.Movement();
       
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        Debug.Log("Damage!");        
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("inCombat", true);

        Health--;
        if (Health < 1)
        {
            anim.SetTrigger("Death");            
            isDead = true;
            Destroy(this.gameObject, 4.0f);
            GameObject diamond = (GameObject)Instantiate(_diamondPreFab, (transform.position + new Vector3(-0.5f, 0.07f, 0)), Quaternion.identity);
            diamond.GetComponent<Diamonds>().gems = base.gems;

        }
    }
    //
}
