using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    private CharacterModifiers chmod;
    public CharacterAttack charAtt;
    bool targetBool = false;
    private List<GameObject> Enemies;
    private GameManager gm;

    Vector3 lastPos, currPos;
    public Transform target;

    private void OnDrawGizmos()
    {
        chmod = gameObject.GetComponent<CharacterModifiers>();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chmod.viewDistance);
    }
    // Use this for initialization
    void Start () {
        chmod = gameObject.GetComponent<CharacterModifiers>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        Enemies = gm.Enemies;
        lastPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        currPos = transform.position;

        chmod.tempMoveDistance -= Vector3.Distance(lastPos, currPos);

        if(chmod.maxHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void LateUpdate()
    {
        lastPos = transform.position;
    }
    public void moveAI()
    {
        float view = chmod.viewDistance;
        if (!validTarget())
        {
            Collider[] collisions = Physics.OverlapSphere(transform.position, view, 1 << LayerMask.NameToLayer("Player"));
            if (collisions.Length != 0)
            {
                bool hasTarget = false;
                foreach(Collider c in collisions)
                {
                    bool foundTarget = false;
                    foreach (GameObject g in Enemies)
                    {
                        if(g.GetComponent<EnemyAI>().target == c.gameObject)
                        {
                            foundTarget = true;
                        }
                        if (foundTarget) break;
                        else
                        {
                            target = c.transform;
                            hasTarget = true;
                            break;
                        }
                    }
                    if (hasTarget) break;
                }
            }
            else
            {
                target = null;
            }
        }
        if(target != null)
        {
            if(Vector3.Distance(transform.position, target.position) <= chmod.attackDistance)
            {
                charAtt.Attack(target.gameObject);
                Debug.Log("ATTACK!");
            }
            else
            {
                adjustPos(target);
            }
            
        }
    }

    void adjustPos(Transform targ)
    {
        if(chmod.tempMoveDistance > chmod.attackDistance)
        {
            float tempMove = chmod.tempMoveDistance - chmod.attackDistance;
            transform.position = Vector3.MoveTowards(transform.position, target.position, Random.Range(tempMove, chmod.tempMoveDistance - tempMove));
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, chmod.tempMoveDistance);
        }
    }

    bool validTarget()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) <= chmod.viewDistance)
            {
                return true;
            }
        }
        return false;
    }
}
