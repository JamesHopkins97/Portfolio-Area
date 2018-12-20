using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDistance : MonoBehaviour {

    private CharacterModifiers charMod;
    private float viewDistance;

    private void OnDrawGizmos()
    {
        charMod = gameObject.GetComponent<CharacterModifiers>();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, charMod.viewDistance);
    }
    // Use this for initialization
    void Start () {
        charMod = gameObject.GetComponent<CharacterModifiers>();
        viewDistance = charMod.viewDistance;
	}
	
	// Update is called once per frame
	void Update () {
        Collider[] colliders = Physics.OverlapSphere(transform.position, viewDistance); //1 << LayerMask.NameToLayer("Enemy")

        if (colliders.Length != 0)
        {
            foreach(Collider c in colliders) {
                Renderer r = c.GetComponentInChildren<Renderer>();
                if(!r.enabled) c.GetComponentInChildren<Renderer>().enabled = true;
            }
        }
	}
}
