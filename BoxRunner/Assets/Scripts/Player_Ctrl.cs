using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState{
	Run,
	Jump,
	D_Jump,
	Death
}

public class Player_Ctrl : MonoBehaviour {

	public PlayerState PS; 				//상태관리를 위한 변수 PlayerState를 PS로 선언
	public float Jump_Power = 500f;
	public AudioClip[] Sound;

	public Animator animator;

	public GameObject AnotherSpeaker;

	public GameManager GM;


	void Update(){
		GetComponent<Rigidbody>().WakeUp ();
		if (Input.GetKeyDown (KeyCode.Space) && PS != PlayerState.Death) {
			
			if (PS == PlayerState.Jump) {
				D_Jump ();
			}
			if (PS == PlayerState.Run) {
				Jump ();
			}
		}

		//아래 구문은 모바일 터치 관련
		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				if (PS == PlayerState.Jump) {
					D_Jump ();
				}
				if (PS == PlayerState.Run) {
					Jump ();
				}										
			}
		}
	}

	//여기서부턴 변수 선언
	void Jump(){
		PS = PlayerState.Jump;
		GetComponent<Rigidbody>().AddForce (new Vector3 (0,Jump_Power));

		//SoundPlay (2);
		AnotherSpeaker.SendMessage("SoundPlay");

		animator.SetTrigger ("Jump");
		animator.SetBool ("Ground" ,false);
	}

	void D_Jump(){
		PS = PlayerState.D_Jump;
		GetComponent<Rigidbody>().AddForce (new Vector3 (0,Jump_Power));

		//SoundPlay (2);
		AnotherSpeaker.SendMessage("SoundPlay");

		animator.SetTrigger ("D_Jump");
		animator.SetBool ("Ground" ,false);
	}

	void Run(){
		PS = PlayerState.Run;

		animator.SetBool ("Ground", true);
	}

	void OnCollisionEnter(Collision collision){				//()안에 Collision 타입의 변수 collision 입력
		if(PS != PlayerState.Run && PS != PlayerState.Death){
			Run ();
		}
}
	void CoinGet(){
		SoundPlay (0);

		if (GM != null) {			//"GM이 비어있지 않을 때"를 넣는 이유는 ItroScene에 남아있는 player스크립트에서 gamemanager 스크립트가 붙어있는 오브젝트인 gui가 사라져 오류가 발생하기 때문.
			GM.CoinGet ();			
		}
	}

	void GameOver(){
		PS = PlayerState.Death;
		SoundPlay (1);

		GM.GameOver ();
	}

	void SoundPlay(int Num){
		GetComponent<AudioSource>().clip = Sound [Num];
		GetComponent<AudioSource>().Play ();
	 }

	void OnTriggerEnter(Collider other){
		GetComponent<Rigidbody>().WakeUp ();
		if (other.gameObject.name == "Coin") {
			Destroy (other.gameObject);
			CoinGet ();
		}
		if (other.gameObject.name == "DeathZone" && PS != PlayerState.Death) {
			GameOver ();
		}
	}
}
