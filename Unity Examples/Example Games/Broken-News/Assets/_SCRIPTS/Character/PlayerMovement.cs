using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public Transform targetPrefab;

    [SerializeField] UnityEngine.AI.NavMeshAgent nav;

    Vector3 lastPos, currPos;

    GameObject target;

    private  CharacterModifiers charMod;

    private CharacterAttack charAtt;

    private RadiusDisplay MoveM;

    bool drawRadius = false;
    private void Start()
    {
        charMod = GetComponent<CharacterModifiers>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        targetPrefab = GameObject.Find("GameManager").GetComponent<GameManager>().targetPrefabForPlayers.transform;
        lastPos = transform.position;
        nav.SetDestination(transform.position);
        charAtt = this.GetComponent<CharacterAttack>();
        MoveM = this.GetComponent<RadiusDisplay>();

    }

    // Update is called once per frame
    void Update()
    {
        currPos = transform.position;
        if (Input.GetButtonDown("Fire2") && charMod.hasMove && charMod.tempMoveDistance > 0 && charMod.characterSelected)
        {
            CastRay();
            drawRadius = true;
        }

        if (drawRadius == true)
        {
            MoveM.DrawPoints();
        }
        charMod.tempMoveDistance -= Vector3.Distance(lastPos, currPos);
        if (charMod.tempMoveDistance <= 0 || Input.GetKeyDown(KeyCode.E))
        {
            EndJourney();
            drawRadius = false;
        }
        

    }

    public void SetTargetForPlayer(Transform transform)
    {
        nav.SetDestination(transform.position);
    }

    private void EndJourney()
    {
        charMod.hasMove = false;
        Destroy(target);
        nav.SetDestination(transform.position);
    }

    public  void CastRay()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.name != "Enemy")
            {
                if(this.name == "Intern" && hit.transform.tag == "Player")
                {
                    if (charMod.attackDistance >= Vector3.Distance(this.transform.position, hit.transform.position))
                    {
                        if (charMod.hasMove)
                        {
                            if(hit.transform.name == "CoffeeMachine")
                            {
                                if (hit.transform.GetComponent<CoffeeMachineScript>().numberOfCoffees > 0)
                                {
                                    this.GetComponent<InternCoffeeHolding>().holdingCoffees++;
                                    hit.transform.GetComponent<CoffeeMachineScript>().numberOfCoffees--;
                                    EndJourney();
                                }
                                else
                                {
                                    Debug.Log("Cannot take Coffees");
                                }
                            }
                            else if(hit.transform.name == "CameraMan" || hit.transform.name == "MicMan" || hit.transform.name == "Reporter")
                            {
                                if(this.GetComponent<InternCoffeeHolding>().holdingCoffees > 0 && !hit.transform.GetComponent<CharacterModifiers>().isCaffeinated)
                                {
                                    this.GetComponent<InternCoffeeHolding>().giveCoffee(hit.transform);
                                }
                            }
                        }

                    }
                    else if(this.name == "Intern" && charMod.hasMove)
                    {
                        target = Instantiate(targetPrefab.gameObject, hit.point, transform.rotation);
                        target.GetComponent<MovementMarker>().setHost(this.gameObject);
                        SetTargetForPlayer(target.transform);
                    }
                    else
                    {
                        target = Instantiate(targetPrefab.gameObject, hit.point, transform.rotation);
                        float tempDist = Vector3.Distance(this.transform.position, hit.transform.position) - (charMod.attackDistance + 1f);
                        target.transform.position = Vector3.MoveTowards(target.transform.position, this.transform.position, tempDist);
                        target.GetComponent<MovementMarker>().setHost(this.gameObject);
                        SetTargetForPlayer(target.transform);
                    }
                    
                }
                else
                {
                    target = Instantiate(targetPrefab.gameObject, hit.point, transform.rotation);
                    target.GetComponent<MovementMarker>().setHost(this.gameObject);
                    SetTargetForPlayer(target.transform);
                }
                
            }
            else
            {
                if(charMod.attackDistance >= Vector3.Distance(this.transform.position, hit.transform.position))
                {
                    charAtt.Attack(hit.transform.gameObject);
                    EndJourney();
                }
                else
                {
                    target = Instantiate(targetPrefab.gameObject, hit.point, transform.rotation);
                    float tempDist = Vector3.Distance(this.transform.position, hit.transform.position) - (charMod.attackDistance + 1f);
                    target.transform.position = Vector3.MoveTowards(target.transform.position, this.transform.position, tempDist);
                    target.GetComponent<MovementMarker>().setHost(this.gameObject);
                    SetTargetForPlayer(target.transform);
                }
            }
            
        }
    }

    private void LateUpdate()
    {
        lastPos = transform.position;
        if (target != null)
        {
            if (lastPos == target.transform.position)
            {
                nav.SetDestination(transform.position);
            }
        }
    }

    public GameObject getTarget()
    {
        return target;
    }


}
