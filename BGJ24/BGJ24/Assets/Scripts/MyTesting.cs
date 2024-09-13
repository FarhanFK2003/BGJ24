using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTesting : MonoBehaviour
{
    [SerializeField] GameObject pobj;
    void Start()
    {

        GameObject[] objs = new GameObject[pobj.transform.childCount];
        for(int i = 0; i < objs.Length; i++)
        {
            objs[i] = pobj.transform.GetChild(i).gameObject;
        }
        Vector3 vector3 = new Vector3();
        foreach (var obj in objs) 
        {
            vector3 += obj.transform.position;
        }
        vector3/=objs.Length;
        
        Debug.Log(vector3);
    }

}
