using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Loop : MonoBehaviour {

	public float Speed = 3;		//블럭들이 움직일 스피드
	public GameObject[] Block;	//계속해서 만들 블럭, []붙이면 여러가지 변수가 들어갈 수 있는 배열식 변수
	public GameObject A_Zone;	//가운데에 있는 블럭
	public GameObject B_Zone;	//화면의 오른쪽에 있는 블럭

	void Update(){
		Move ();
	}

	void Move(){
		A_Zone.transform.Translate (Vector3.left * Speed * Time.deltaTime);
		B_Zone.transform.Translate (Vector3.left * Speed * Time.deltaTime);

		if (B_Zone.transform.position.x<=0) {

			Destroy (A_Zone);

			A_Zone = B_Zone;
			Make ();
		}
	}

	void Make(){
		int A = Random.Range (0, Block.Length);  	//블럭 랜덤 생성하는 변수 A 선언
		B_Zone = Instantiate (Block[A], new Vector3 (A_Zone.transform.position.x+30, -5, 0), transform.rotation) as GameObject;
		//Instantiate 함수는 새로운 오브젝트를 생성하는 역할을 한다.  Instantiate(게임오브젝트, 만들 위치, 만들 오브젝트 회전값)
		//새롭게 Block을 만들되, position값을 (30, -5, 0)으로 해서, 화면의 바깥 쪽에 새롭게 블럭을 만들어 B_Zone에 대입시킨다.
		//A_Zone.transform.position.x+30  :  블럭 생성시 틈 최소화를 위해, 블럭 생성 시점에 오차 발생 체크하여 딱 맞는 위치에 생성
	}
}
