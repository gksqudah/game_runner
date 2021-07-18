using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Send : MonoBehaviour {

	public GameObject Target;			//메시지를 전달할 타겟이 될 오브젝트를 Target으로 선언
	public string MethodName;			//전달할 메시지(함수의 이름)의 내용이 들어갈 MethodName 선언

	public void OnMouseDown(){
		Target.SendMessage (MethodName);	//Target에 MethodName의 함수 실행
	}
}
