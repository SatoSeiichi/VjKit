using UnityEngine;
using System.Collections;

public class Demo1_Script : MonoBehaviour {

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
		//Debug.Log(keyName);
		//Debug.Log(keyValue);
	}
	
	//キーが押された場合に呼び出される関数
	public void nanoKontrol2_keyPushed(string keyName)
	{
		//Debug.Log(keyName);
	}
	
	
	//スライダーやノブの値の取得
	void Update () {
		transform.localScale = new Vector3(nanoKontrol2.Slider1+1,nanoKontrol2.Slider2+1,nanoKontrol2.Slider3+1);
	}

}
