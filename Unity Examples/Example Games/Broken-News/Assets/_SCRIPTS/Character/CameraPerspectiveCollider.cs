using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerspectiveCollider : MonoBehaviour {

    List<string> names;
    public GameManager gm;
    public CharacterModifiers cm;
    public Camera cam;
    public Transform ReporterCharacter;
	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateEvery5Seconds", 0f, 5f);
	}
	
    void UpdateEvery5Seconds()
    {
        cam.transform.LookAt(ReporterCharacter);
        ScoreManager sc = gm.scoreManager;
        sc.camMultiplier = 3;

        if (I_Can_See(ReporterCharacter.gameObject))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, ReporterCharacter.gameObject.transform.position, out hit, cm.viewDistance)) //cm.viewDistance
            {
                sc.camMultiplier += 1;
            }
        }
        if (I_Can_See(gm.Players[2]))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, gm.Players[2].transform.position, out hit, cm.viewDistance)) //cm.viewDistance
            {
                sc.camMultiplier -= 1;
            }
        }
        if (I_Can_See(gm.Players[3]))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, gm.Players[3].transform.position, out hit, cm.viewDistance)) //cm.viewDistance
            {
                sc.camMultiplier -= 1;
            }
        }
        if (I_Can_See(sc.objective.gameObject))
        {
                sc.camMultiplier += 1;
        }
    }

    private bool I_Can_See(GameObject Object)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, Object.GetComponent<Collider>().bounds))
            return true;
        else
            return false;
    }
}
