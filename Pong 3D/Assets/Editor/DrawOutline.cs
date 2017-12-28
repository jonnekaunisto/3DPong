//Jonne Kaunisto, December 2017
//makes outline for planes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOutline : MonoBehaviour {

	public Color color = Color.green; //color of outline
	public float thickness = 0.1f;
	public Material material;
	float sizeX;
	float sizeY;


	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer> ().enabled = false;
		Bounds bounds = GetComponent<MeshFilter> ().mesh.bounds;
		sizeX = bounds.size.x * 0.5f * transform.lossyScale.x;
		sizeY = bounds.size.z * 0.5f * transform.lossyScale.y;

		Vector3 corner1 = new Vector3 (sizeX, sizeY, transform.position.z);
		Vector3 corner2 = new Vector3 (-sizeX, sizeY, transform.position.z);
		Vector3 corner3 = new Vector3 (-sizeX, -sizeY, transform.position.z);
		Vector3 corner4 = new Vector3 (sizeX, -sizeY, transform.position.z);
		//Bounds bounds = GetComponent<MeshFilter> ().mesh.bounds;

		LineDrawer.DrawLine (corner1, corner2, thickness, material, transform);
		LineDrawer.DrawLine (corner2, corner3, thickness, material, transform);
		LineDrawer.DrawLine (corner3, corner4, thickness, material, transform);
		LineDrawer.DrawLine (corner4, corner1, thickness, material, transform);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
