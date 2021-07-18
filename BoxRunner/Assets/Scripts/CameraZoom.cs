using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

	public Camera camera;		//Camera타입의 변수 camera 선언
	public GameObject player;

	public float speed = 0.5f;
	float cameraSize = 5f;

	public float MaxSize = 10f;
	public float MinSize = -5f;

	
	// Update is called once per frame
	void Update () {

		//camera.orthographicSize = 5f + player.transform.position.y;			//camera 변수의 orthographicSize를 play의 y값에 따라 변하게 함

		cameraSize = 5f + player.transform.position.y;

		if (cameraSize >= MaxSize) {
			cameraSize = MaxSize;
		}
		if (cameraSize <= MinSize) {
			cameraSize = MinSize;
		}
		camera.orthographicSize = Mathf.Lerp (camera.orthographicSize, cameraSize, Time.deltaTime / speed);		//미리 cameraSize 값을 측정한 뒤 Mathf.Lerp() 함수를 이용하여, 현재 값에서 우리가 원하는 값으로 일정한 속도만큼 부드럽게 변경
																												//Math.Lerp(바꾸기 전의 값, 바꿀 값, 바뀔 시간을 계산할 수치)를 이용하면 특정 값을 부드럽게 바꾸는데 자주 사용되는 구문
	}
}
