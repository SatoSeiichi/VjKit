using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
このスクリプトはNanoKontrol2プレハブから利用されます


nanoKontrol2のMIDIデータメモ

ノブ（左から順番に）
Data1:16から23
Data2:0から127までの値

スライダー
Data1:0から7
Data2:0から127までの値

ボタン
Data1：ボタンの場所
Data2：おした時127   話した時0

ボタンの場所
S（左から順番に）32から39
M（左から順番に）48から55
R（左から順番に）64から71
TRACK 左58  右59
CYCLE 46
MAKER SET60  左61  右62
戻す43
進む44
停止42
再生41
録音45
*/

public class NanoKontrol2 : MonoBehaviour {

	//スライダー値格納変数
	public int Slider1=0;
	public int Slider2=0;
	public int Slider3=0;
	public int Slider4=0;
	public int Slider5=0;
	public int Slider6=0;
	public int Slider7=0;
	public int Slider8=0;

	//ノブ値格納変数
	public int knob1=0;
	public int knob2=0;
	public int knob3=0;
	public int knob4=0;
	public int knob5=0;
	public int knob6=0;
	public int knob7=0;
	public int knob8=0;

	public string PushedKey = "";

	public void qued(int status, int data1, int data2){
		switch (data1) {
		case 0:
			Slider1=data2;
			valueChanged("Slider1",data2);
			break;
		case 1:
			Slider2=data2;
			valueChanged("Slider2",data2);
			break;
		case 2:
			Slider3=data2;
			valueChanged("Slider3",data2);
			break;
		case 3:
			Slider4=data2;
			valueChanged("Slider4",data2);
			break;
		case 4:
			Slider5=data2;
			valueChanged("Slider5",data2);
			break;
		case 5:
			Slider6=data2;
			valueChanged("Slider6",data2);
			break;
		case 6:
			Slider7=data2;
			valueChanged("Slider7",data2);
			break;
		case 7:
			Slider8=data2;
			valueChanged("Slider8",data2);
			break;

		case 16:
			knob1=data2;
			valueChanged("Knob1",data2);
			break;
		case 17:
			knob2=data2;
			valueChanged("Knob2",data2);
			break;
		case 18:
			knob3=data2;
			valueChanged("Knob3",data2);
			break;
		case 19:
			knob4=data2;
			valueChanged("Knob4",data2);
			break;
		case 20:
			knob5=data2;
			valueChanged("Knob5",data2);
			break;
		case 21:
			knob6=data2;
			valueChanged("Knob6",data2);
			break;
		case 22:
			knob7=data2;
			valueChanged("Knob7",data2);
			break;
		case 23:
			knob8=data2;
			valueChanged("Knob8",data2);
			break;
		
		
		case 41:
			if(data2==0){
				PushedKey="PLAY";
				keyPushed(PushedKey);
			}
			break;

		case 42:
			if(data2==0){
				PushedKey="STOP";
				keyPushed(PushedKey);
			}
			break;

		
		case 43:
			if(data2==0){
				PushedKey="BACK";
				keyPushed(PushedKey);
			}
			break;

		case 44:
			if(data2==0){
				PushedKey="FORWARD";
				keyPushed(PushedKey);
			}
			break;

		case 45:
			if(data2==0){
				PushedKey="RECORD";
				keyPushed(PushedKey);
			}
			break;

		case 46:
			if(data2==0){
				PushedKey="CYCLE";
				keyPushed(PushedKey);
			}
			break;

		case 58:
			if(data2==0){
				PushedKey="TRACK_LEFT";
				keyPushed(PushedKey);
			}
			break;

		case 59:
			if(data2==0){
				PushedKey="TRACK_RIGHT";
				keyPushed(PushedKey);
			}
			break;


		case 60:
			if(data2==0){
				PushedKey="MAKER_SET";
				keyPushed(PushedKey);
			}
			break;

		case 61:
			if(data2==0){
				PushedKey="MAKER_LEFT";
				keyPushed(PushedKey);
			}
			break;

		case 62:
			if(data2==0){
				PushedKey="MAKER_RIGHT";
				keyPushed(PushedKey);
			}
			break;


		default:
			if(data1>=32 && data1<=39){
				if(data2==0){
					PushedKey="S" + (data1-31).ToString();
					keyPushed(PushedKey);
				}
			}

			if(data1>=48 && data1<=55){
				if(data2==0){
					PushedKey="M" + (data1-47).ToString();
					keyPushed(PushedKey);
				}
			}

			if(data1>=64 && data1<=71){
				if(data2==0){
					PushedKey="R" + (data1-63).ToString();
					keyPushed(PushedKey);
				}
			}


			break;

		}
	}
	
	//キー（スライダー・ノブ）の値が変更された場合コールバック関数を呼び出す
	public delegate void valueChangedFunctionDelegate(string keyName,int keyValue);
	public List<valueChangedFunctionDelegate> valueChangedFunctions;
	void valueChanged(string keyName,int keyValue){
		foreach(valueChangedFunctionDelegate valueChangedFunction in valueChangedFunctions){
			valueChangedFunction(keyName,keyValue);
		}
	}

	//キーが押された場合コールバック関数を呼び出す
	public delegate void keyPushedFunctionDelegate(string keyName);
	public List<keyPushedFunctionDelegate> keyPushedFunctions;
	void keyPushed(string keyName){
		foreach(keyPushedFunctionDelegate keyPushedFunction in keyPushedFunctions){
			keyPushedFunction(keyName);
		}
	}

	void Awake(){
		valueChangedFunctions = new List<valueChangedFunctionDelegate>();
		keyPushedFunctions = new List<keyPushedFunctionDelegate>();
	}


}
