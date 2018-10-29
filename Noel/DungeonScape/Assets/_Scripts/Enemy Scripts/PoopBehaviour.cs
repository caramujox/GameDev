using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopBehaviour : MonoBehaviour {
    //Variaveis
    private bool _canDamage = true;
    

    //Metodos
    public void OnTriggerEnter2D(Collider2D other)
    {
        IDamageble hitTarget = other.GetComponent<IDamageble>();
        if (hitTarget != null)
        {
            if (other.tag == "Player")
            {
                hitTarget.Damage();
                _canDamage = false;
                StartCoroutine(ResetCanDamage());
                Destroy(this.gameObject);
            }
        }
        else if (other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator ResetCanDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
