using UnityEngine;
using System.Collections;
using ETC.Platforms;

/// <summary>
/// An example lighting manager using the DMX class to interface with an Enttec DMX USB Pro.
/// Requires one RGB 3-channel fixture connected as device 1 (i.e. channels 1 through 3).
/// </summary>
/// <remarks>
/// Author: Bryan Maher (bm3n@andrew.cmu.edu) 26-Jan-2015
/// 
/// Feel free to use this example code as starting point for your own project.
/// </remarks>
public class LightingManagerExample : MonoBehaviour {
	/// <summary>
	/// Set this Editor property to the value of the DMX controller's COM port.
	/// <example>COM22</example>
	/// </summary>
	public string ComPort;

	/// <summary>
	/// Instance of the DMX class used to control the lights.
	/// </summary>
	private DMX dmx;

	// Use this for initialization
	IEnumerator Start () {
		this.dmx = new DMX(this.ComPort);

		this.SetColor(Color.black);

		// Cycle through the color wheel
		yield return StartCoroutine(FadeColor(Color.black, Color.red, 5f));
		yield return StartCoroutine(FadeColor(Color.red, Color.yellow, 5f));
    	yield return StartCoroutine(FadeColor(Color.yellow, Color.green, 5f));
		yield return StartCoroutine(FadeColor(Color.green, Color.blue, 5f));
		yield return StartCoroutine(FadeColor(Color.blue, Color.magenta, 5f));
		yield return StartCoroutine(FadeColor(Color.magenta, Color.white, 5f));
		yield return StartCoroutine(FadeColor(Color.white, Color.black, 5f));
	}

	/// <summary>
	/// Sets the lighting fixture to given color.
	/// </summary>
	/// <param name="color">Desired color.</param>
	private void SetColor(Color color)
	{
        int deviceID = 7;

		this.GetComponent<Camera>().backgroundColor = color;
        this.dmx.Channels[deviceID + 0] = (byte)(86);
        this.dmx.Channels[deviceID + 1] = (byte)(255);

        this.dmx.Channels[deviceID + 2] = (byte)(Mathf.FloorToInt(255f * color.r));
		this.dmx.Channels[deviceID + 3] = (byte)(Mathf.FloorToInt(255f * color.g));
		this.dmx.Channels[deviceID + 4] = (byte)(Mathf.FloorToInt(255f * color.b));
		this.dmx.Send();
	}

	/// <summary>
	/// Performs smooth transition between two colors over the given duration.
	/// </summary>
	/// <param name="startColor">Intial color.</param>
	/// <param name="endColor">Final color.</param>
	/// <param name="duration">Duration of transition in seconds.</param>
	private IEnumerator FadeColor(Color startColor, Color endColor, float duration)
	{
		float startTime = Time.time;
		float elapsed = 0;

		while(elapsed < duration)
		{
			float t = elapsed / duration;
			Color lerpedColor = Color.Lerp(startColor, endColor, t);
			this.SetColor(lerpedColor);
			yield return 0;
			elapsed = Time.time - startTime;
		}
	}
}
