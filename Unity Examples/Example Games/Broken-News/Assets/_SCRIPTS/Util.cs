using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {

	public static GameObject[] FindObjectsWithLayer(int layer)
    {

        GameObject[] array = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List <GameObject> goArray = new List<GameObject>();
        for(int i = 0; i <array.Length; i++)
        {
            if(array[i].layer == layer)
            {
                goArray.Add(array[i]);
            }
        }
        if(goArray.Count == 0)
        {
            return null;
        }
        return goArray.ToArray();
    }
}
