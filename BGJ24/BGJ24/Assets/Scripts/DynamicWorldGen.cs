using System;
using UnityEngine;

public class DynamicWorldGen : MonoBehaviour
{

	[SerializeField] GameObject emptyChunckObj;
	[SerializeField] GameObject[] spawnObjs;
	[SerializeField] LayerMask objsCanCollide;
	[SerializeField] Transform patchesParent;
	[SerializeField] Transform emptyChuncksParent;




	private float buildingCheckRadius = 90;
	private float[,] surroundingAreas = { {100,0 },{ 0,100} ,{ 100,100},{ -100,0},{0,-100 },{-100,-100 },{ -100,100},{ 100,-100} };

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "EmptyChunck")
		{
            Vector3 pos = other.transform.position;
            Debug.Log($"{other.name} {pos}");
            Destroy(other.gameObject);


            Instantiate(spawnObjs[UnityEngine.Random.Range(0, spawnObjs.Length)], pos, Quaternion.identity, patchesParent);

            Collider[] objs = Physics.OverlapSphere(pos, buildingCheckRadius, objsCanCollide);
            for (int i = 0; i < surroundingAreas.GetLength(0); i++)
            {
                Vector3 newPos = new Vector3(pos.x + surroundingAreas[i, 0], 0, pos.z + surroundingAreas[i, 1]);
                if (!Array.Find(objs, obj => obj.transform.position == newPos))
                {
                    Instantiate(emptyChunckObj, newPos, Quaternion.identity, emptyChuncksParent);
                }
            }
        }
		
	}
}
