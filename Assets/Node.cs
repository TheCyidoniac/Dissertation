using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node{

	public Waypoint waypoint;
	public Node parent;

	public float gCost;
	public float hCost;
	public float fCost {
		get{
			return gCost + hCost;
		}
	}

	public Node(Waypoint _waypoint, Node _parent, float _gCost, float _hCost){
		waypoint = _waypoint;
		parent = _parent;
		gCost = _gCost;
		hCost = _hCost;
	}
}
