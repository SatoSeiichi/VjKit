using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ETC.Platforms;

public class DmxExample : MonoBehaviour {
	private DMX dmx;
	public string port;
	public byte setup;
	public byte red;
	public byte green;
	public byte blue;
	
	const int DMX_Ch_MAX = 4;
	
	private string SliderName = "Slider";
	private string KnobName = "Knob";
	private string S_Button = "S";
	private string M_Button = "M";
	private string R_Button = "R";
	
	//nanoKontrol2を宣言
	public NanoKontrol2 nanoKontrol2;
	
	public byte[] sliderValue = new byte[4];
	public byte[] knobValue = new byte[4];
	
	public GameObject[] obj = new GameObject[4];
	
	// Use this for initialization
	void Start () {
		this.dmx = new DMX(port);
		this.dmx.Channels[1] = setup;
		this.dmx.Channels[2] = red;
		this.dmx.Channels[3] = green;
		this.dmx.Channels[4] = blue;
		this.dmx.Send();
		
		//Start()の中でコールバック関数の設定を行う
		nanoKontrol2.valueChangedFunctions.Add (nanoKontrol2_valueChanged);
		nanoKontrol2.keyPushedFunctions.Add (nanoKontrol2_keyPushed);
	}
	
	// Update is called once per frame
	void Update () {
		//this.dmx.Channels[1] = setup;
		//this.dmx.Channels[2] = red;
		//this.dmx.Channels[3] = green;
		//this.dmx.Channels[4] = blue;
		//this.dmx.Send();
	}
	
	//キー（スライダー・ノブ）の値が変更された場合に呼び出される関数
	public void nanoKontrol2_valueChanged(string keyName, int keyValue)
	{
		int i = 0;
		if (0 <= keyName.IndexOf(SliderName)) {

			i = int.Parse(keyName.Replace(SliderName,""));
			if(i > DMX_Ch_MAX)return;
			sliderValue[i -1] = (byte)(keyValue);
		}
		
		if (0 <= keyName.IndexOf(KnobName)) {
			i = int.Parse(keyName.Replace(KnobName,""));
			if(i > DMX_Ch_MAX)return;
			knobValue[i -1] = (byte)(keyValue);
		}
		DmxUpDate(i);
	}
	
	public void DmxUpDate(int keyIndex)
	{
		int i = keyIndex-1;
		switch(i)
		{
		case 0:
			this.dmx.Channels[1] = setup = (byte)(sliderValue[i] + knobValue[i]);
			break;
		case 1:
			this.dmx.Channels[2] = red = (byte)(sliderValue[i] + knobValue[i]);
			break;
		case 2:
			this.dmx.Channels[3] = green = (byte)(sliderValue[i] + knobValue[i]);
			break;
		case 3:
			this.dmx.Channels[4] = blue = (byte)(sliderValue[i] + knobValue[i]);
			break;
		}
		
		obj[i].transform.position = new Vector3(obj[i].transform.position.x, sliderValue[i]/10, obj[i].transform.position.z);
		obj[i].transform.rotation = Quaternion.Euler(knobValue[i], 0, 0);
		this.dmx.Send();
	}
	
	//キーが押された場合に呼び出される関数
	public void nanoKontrol2_keyPushed(string keyName)
	{
		
		//if(S_Button == keyName){
		//	GetComponent<Renderer> ().material.color = Color.blue;
		//}
		//if(M_Button == keyName){
		//	GetComponent<Renderer> ().material.color = Color.red;
		//}
		//if(R_Button == keyName){
		//	GetComponent<Renderer> ().material.color = Color.green;
		//}
		
	}
}
