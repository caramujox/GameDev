using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageble{
    [SerializeField]
    private GameObject _projectilePreFab;
    [SerializeField]
    private GameObject _diamondPreFab;
    public int Health { get; set; }
    //Usa para inicializacao (quase um construtor)
    public override void Initializer()
    {
        base.Initializer();
        base.health = 1;
        Health = base.health;
        base.gems = 3;

    }

    public override void Movement()
    {
        //wait
    }

    public void Damage()
    {
        if (isDead == true)
        {
            return;
        }
        Health--;
        if (Health < 1)
        {
            isDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = (GameObject)Instantiate(_diamondPreFab, (transform.position + new Vector3(-0.5f, 0.07f, 0)), Quaternion.identity);
            diamond.GetComponent<Diamonds>().gems = base.gems;
            Destroy(this.gameObject, 4.0f);
        }
    }

    public void Attack()
    {
        Instantiate(_projectilePreFab, (transform.position + new Vector3(-0.5f, 0.07f, 0)), Quaternion.identity);
    }

    public override void Update()
    {
        
    }
    //
}
