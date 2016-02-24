using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Raycasttest : MonoBehaviour {
	public Waypoint[] objects;


	Ray ray;
	RaycastHit hit;
	Node EndNode;
	Node[] listNode = new Node[8];

	// Use this for initialization
	void Start () {
		//objects.Add(
		buildGraph ();

	}

	// Update is called once per frame
	void Update () {
	}

	void buildGraph () {
		objects = GameObject.FindObjectsOfType<Waypoint>();
		for (int i = 0; i < objects.Length; i++) {
			for (int y = 0; y < objects.Length; y++) {
				Ray ray = new Ray (objects [y].transform.position, (objects [i].transform.position - objects [y].transform.position));
				//Physics.Raycast (objects [0].transform.position, (objects [1].transform.position - objects [0].transform.position));
				
				if (i != y && Physics.Raycast (ray) == false) {
					objects[i].listWaypoint.Add(objects[y]);
					//Vector3.Distance(objects [y].transform.position, objects [0].transform.position);
					Debug.DrawRay (objects [y].transform.position, (objects [i].transform.position - objects [y].transform.position), Color.black, Mathf.Infinity);
				}
			}
		}
	}

	public void aStar (Node start, Node end) {
		List<Node> openList = new List<Node>();
		List<Node> closedList = new List<Node>();
		List<Node> path = new List<Node> ();
		Node currentNode = new Node (start.waypoint, null, 0, Vector3.Distance (start.waypoint.transform.position, end.waypoint.transform.position));

		openList.Add (currentNode);

		while(currentNode != end || openList.Count != 0){
			for(int y = 0; y <= openList.Count; y++){
				if(openList[y].fCost < currentNode.fCost || (openList[y].fCost == currentNode.fCost && openList[y].hCost < currentNode.hCost)){
					currentNode = openList[y];
					closedList.Add(openList[y]);
				}
			}
			for(int i = 0; i <= currentNode.waypoint.listWaypoint.Count; i++){
				for(int z = 0; z < closedList.Count; z++)
				{
					if(closedList[z].waypoint.listWaypoint.Contains(currentNode.waypoint.listWaypoint[i])){
						Debug.Log("skipped");
						continue;
						}
					else{
						float Gcost = Vector3.Distance(currentNode.waypoint.transform.position, currentNode.waypoint.listWaypoint[i].transform.position);
						float Hcost = Vector3.Distance(currentNode.waypoint.listWaypoint[i].transform.position, end.waypoint.transform.position);
						openList.Add(new Node(currentNode.waypoint.listWaypoint[i], currentNode, Gcost, Hcost));
					} 
				}
				for(int y = 0; y < openList.Count; y++)
					if(openList[y].waypoint.listWaypoint.Contains(currentNode.waypoint.listWaypoint[i])){
						if(openList[y].gCost < currentNode.gCost){
						openList[y].parent = currentNode;
					}
				}

				path.Add(currentNode);
				Debug.Log(path);

			}
		}

	}

}

