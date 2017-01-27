using UnityEngine;
using System.Collections.Generic;


// MIDI Receiver class.
public class MidiReceiver : MonoBehaviour
{
	//nanoKontrol2変数を定義
	private NanoKontrol2 nanoKontrol2;

    Queue<MidiMessage> messageQueue;

    public bool IsEmpty {
        get { return messageQueue.Count == 0; }
    }
    
    public MidiMessage PopMessage ()
    {
        return messageQueue.Dequeue ();
    }

#if UNITY_EDITOR
    Queue<MidiMessage> messageHistory;

    public Queue<MidiMessage> History {
        get { return messageHistory; }
    }
#endif

	void Start () {
		//nanoKontrol2スクリプトを取得
		nanoKontrol2 = transform.GetComponent<NanoKontrol2>();
	}


    void Awake ()
    {
		

        messageQueue = new Queue<MidiMessage> ();
#if UNITY_EDITOR
        messageHistory = new Queue<MidiMessage> ();
#endif
    }

    void Update ()
    {
        while (true) {
            var data = UnityMidiReceiver.DequeueIncomingData ();
            if (data == 0) {
                break;
            }

            var message = new MidiMessage (data);
            messageQueue.Enqueue (message);

			//nanoKontrol2スクリプトへデータを渡す
			nanoKontrol2.qued((int)message.status, (int)message.data1, (int)message.data2);

#if UNITY_EDITOR
            messageHistory.Enqueue (message);
#endif
        }
#if UNITY_EDITOR
        while (messageHistory.Count > 8) {
            messageHistory.Dequeue ();
        }
#endif
    }
}