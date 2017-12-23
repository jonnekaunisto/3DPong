//Jonne Kaunisto, December 2017
//draws lines
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour {


	public static void DrawLine(Vector3 start, Vector3 end, float thickness, Color color, Transform transform){
		
		//gets midpoint and length
		float distance = Vector3.Distance (start, end)* 0.5f;
		Vector3 midPoint = new Vector3 (((start.x + end.x) * 0.5f), ((start.y + end.y) * 0.5f), ((start.z + end.z) * 0.5f));

		//creates the line GameObject
		Material lineMaterial = new Material (Shader.Find ("Standard"));
		lineMaterial.color = color;
		GameObject line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		line.name = "line";
		line.GetComponent<MeshRenderer> ().materials = new Material[]{lineMaterial};

		line.transform.position = midPoint;
		line.transform.localScale = new Vector3 (thickness, distance, thickness);

		//rotates
		line.transform.LookAt (end);
		line.transform.Rotate (new Vector3 (90, 0, 0));
		line.transform.SetParent (transform);

	}


	public static void DrawLine(Vector3 start, Vector3 end, float thickness, Material material, Transform transform){

		//gets midpoint and length
		float distance = Vector3.Distance (start, end)* 0.5f;
		Vector3 midPoint = new Vector3 (((start.x + end.x) * 0.5f), ((start.y + end.y) * 0.5f), ((start.z + end.z) * 0.5f));

		//creates the line GameObject
		GameObject line = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		line.name = "line";
		line.GetComponent<MeshRenderer> ().materials = new Material[]{material};

		line.transform.position = midPoint;
		line.transform.localScale = new Vector3 (thickness, distance, thickness);

		//rotates
		line.transform.LookAt (end);
		line.transform.Rotate (new Vector3 (90, 0, 0));
		line.transform.SetParent (transform);

	}
}
