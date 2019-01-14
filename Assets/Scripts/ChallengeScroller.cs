using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeScroller : MonoBehaviour {

	public float scrollSpeed =5.0f;
	public GameObject[] Challenges;
	public float frequency=0.5f;
	float counter=0.0f;
	public Transform challengesSpawnPoint;

	bool isGameOver=false;
	


	// Use this for initialization
	void Start () {
		GenerateRandomChallenge();
	}
	
	// Update is called once per frame
	void Update () {
//Generate gameobjects
if (isGameOver)return;

      if (counter<=0.0f){
		  GenerateRandomChallenge();
	  }
else{
	counter-=Time.deltaTime*frequency;
}

		//Scroll
		GameObject currentChild;
		for (int i=0;i<transform.childCount;i++){
           currentChild=transform.GetChild(i).gameObject;
		   ScrollChallenge(currentChild);
		   if (currentChild.transform.position.x<=-15){
			   Destroy(currentChild);
		   }
		}
	}

	void ScrollChallenge(GameObject currentChallenge){
		currentChallenge.transform.position+=Vector3.left*(scrollSpeed *Time.deltaTime);
	}

	void GenerateRandomChallenge(){
    GameObject newChallenge=  Instantiate(Challenges[Random.Range(0,Challenges.Length)],challengesSpawnPoint.position,Quaternion.identity) as GameObject;
	newChallenge.transform.parent=transform;
	counter =1.0f;
	}

	void GameOver(){
		isGameOver=true;
	}
}
