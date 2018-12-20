using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CharacterAttack : MonoBehaviour
{
    private CharacterModifiers cm;

	// Use this for initialization
	void Start ()
    {
        cm = gameObject.GetComponent<CharacterModifiers>();
	}
	
    float AttackValue(float distanceMultiplier)
    {

        float attackAmount = 0.0f;


        //Get a random number between max damage /3 and max damage
        attackAmount = Random.Range((cm.maxDamage /3.0f), cm.maxDamage);
        //round the number to 2 D.P
        attackAmount = Mathf.Round(attackAmount * 100f) / 100f;

        int critChance;
        critChance = Random.Range(0, 100);

        if (critChance * (1 + distanceMultiplier) <= cm.critModifier)
        {
            attackAmount *= (Random.Range(1.1f, cm.maxDamage));
        }

      
        return attackAmount;
    }

    public void Attack(GameObject EnemyCharacter)
    {

        float distance = Vector3.Distance(EnemyCharacter.transform.position, transform.position);

        CharacterModifiers eh = EnemyCharacter.GetComponent<CharacterModifiers>();
        
            float attackValue = 1 - (distance / cm.attackDistance);
            float damage = AttackValue(attackValue);


            eh.maxHealth = eh.maxHealth - damage;
       
    }
}

