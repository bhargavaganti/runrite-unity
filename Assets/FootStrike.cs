using UnityEngine;
using System.Collections;

public class FootSrike : MonoBehaviour {

	private ArrayList data = new ArrayList();
	private double mean;

	void FootStike(int[] d){
		data.Add (d);
		mean = 0;
	}

	public void addData(int[] d){
		data.Add (d);
		// calculate new mean
	}

	public ArrayList getData(){
		return data;
	}

	public double getMean(){
		return mean;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
