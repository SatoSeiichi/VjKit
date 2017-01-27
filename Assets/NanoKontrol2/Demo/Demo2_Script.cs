using UnityEngine;
using System.Collections;

public class Demo2_Script : MonoBehaviour {

	public string SliderName = "Slider1";
	public string KnobName = "Knob1";
	public string S_Button = "S1";
	public string M_Button = "M1";
	public string R_Button = "R1";

	//nanoKontrol2を宣言
	private NanoKontrol2 nanoKontrol2;
	
	void Start () {
		//Start()の中でコールバック関数の設定を行う
		nanoKontrol2 = GameObject.Find("NanoKontrol2").GetComponent<NanoKontrol2>();
		nanoKontrol2.valueChangedFunctions.Add (nanoKontrol2_valueChanged);
		nanoKontrol2.keyPushedFunctions.Add (nanoKontrol2_keyPushed);
	}
	
	
	//キー（スライダー・ノブ）の値が変更された場合に呼び出される関数
	public void nanoKontrol2_valueChanged(string keyName, int keyValue)
	{

		if (keyName == SliderName) {
			transform.position = new Vector3(transform.position.x, keyValue/10, transform.position.z);
		}

		if (keyName == KnobName) {
			transform.rotation = Quaternion.Euler(keyValue, 0, 0);
		}




	}
	
	//キーが押された場合に呼び出される関数
	public void nanoKontrol2_keyPushed(string keyName)
	{

		if(S_Button == keyName){
			GetComponent<Renderer> ().material.color = Color.blue;
		}
		if(M_Button == keyName){
			GetComponent<Renderer> ().material.color = Color.red;
		}
		if(R_Button == keyName){
			GetComponent<Renderer> ().material.color = Color.green;
		}

	}
	
	
	//スライダーやノブの値の取得
	void Update () {
		//Debug.Log (nanoKontrol2.Slider1);
		//Debug.Log (nanoKontrol2.Slider2);
		//Debug.Log (nanoKontrol2.knob1);
		//Debug.Log (nanoKontrol2.knob2);
	}
	
	
	
	
}
