using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageble {
    [SerializeField]
    private GameObject _diamondPreFab;
    public int Health { get; set; }
    //Usa para inicializacao (quase um construtor)
    public override void Initializer()
    {
        base.Initializer();
        base.health = 6;
        base.gems = 5;
        Health = base.health;
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
        Debug.Log("MossGiant::Damage!");
        anim.SetTrigger("Hit");
        isHit = true;
        anim.SetBool("inCombat", true);

        Health--;
       
        if (Health < 1)
        {
            anim.SetTrigger("Death");
            isDead = true;
            GameObject diamond = (GameObject) Instantiate(_diamondPreFab, (transform.position + new Vector3(-0.5f, 0.07f, 0)), Quaternion.identity);
            diamond.GetComponent<Diamonds>().gems = base.gems;
            Destroy(this.gameObject, 4.0f);
        }
    }

    //
}
