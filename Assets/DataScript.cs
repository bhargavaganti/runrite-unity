using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class DataScript {

	public class FootStrike {

		private ArrayList data = new ArrayList();
		private double mean;

		public FootStrike(int[] d){
			data.Add (d);
			mean = 0;
		}

		public void addData(int[] d){
			data.Add (d);
			Debug.Log ("data added:" + d[0] + d[1] + d[2] + d[3]);
			// calculate new mean
		}

		public ArrayList getData(){
			return data;
		}

		public double getMean(){
			return mean;
		}
			
	}

	bool zeros;
	int currStrike;
	List<DataScript.FootStrike> feetArr;


	public DataScript(){
		// singleton
	}
		
	public bool receiveData(string datastr) {
		//parse data
		char[] delim = {':'};
		string[] dataArr = datastr.Split (delim);
		int[] nums = new int[5];
		int zerocnt = 0;

		for(int i=0; i<dataArr.Length; i++) {
			int x = 0;
			if ( Int32.TryParse(dataArr[i], out x) ) {
				if (x == 0) zerocnt++;
			}
			nums[i] = x;
			
		}

		Debug.Log ("num1: " + nums[1]);

		if (zerocnt == 5){
			if(!zeros){
				zeros = true;
				currStrike++;
			}
			return false;
				
		} else {
			// if last one was zeros, NEW FOOTSTRIKE
			if(this.zeros){
				DataScript.FootStrike newF = new DataScript.FootStrike (nums);
				feetArr.Add(newF);
			} else {
				feetArr[currStrike].addData(nums);
			}
			return true;
				
		}

		//decide what to do with it
		// if 5 zero's 
			// if have had zeros for a while, just scrap it
			// if first zeros, set zeros flag, increment pointer, scrap it

	}
		
}

