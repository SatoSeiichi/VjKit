using UnityEngine;
using System.Collections;

public class SampleScript_for_NanoKontrol2 : MonoBehaviour {
	
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
		Debug.Log(keyName);
		Debug.Log(keyValue);
	}
	
	//キーが押された場合に呼び出される関数
	public void nanoKontrol2_keyPushed(string keyName)
	{
		Debug.Log(keyName);
	}
	
	
	//任意のタイミングでスライダーやノブの値の取得
	void Update () {
		//Debug.Log (nanoKontrol2.Slider1);
		//Debug.Log (nanoKontrol2.Slider2);
		//Debug.Log (nanoKontrol2.knob1);
		//Debug.Log (nanoKontrol2.knob2);
	}

}
