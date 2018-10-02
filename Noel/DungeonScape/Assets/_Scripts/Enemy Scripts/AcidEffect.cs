using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour {
    //Variaveis Uteis
    private float _speed = 3.0f;
    private bool _canDamage = true;
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
        Destroy(this.gameObject, 3.0f);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageble hitTarget = other.GetComponent<IDamageble>();
        if(hitTarget != null)
        {
            if (other.tag == "Player")
            {
                if (_canDamage == true)
                {
                    hitTarget.Damage();
                    _canDamage = false;
                    StartCoroutine(ResetCanDamage());
                    Destroy(this.gameObject);                    
                }               
            }
        }
            
    }

    IEnumerator ResetCanDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
    
   
//
}
