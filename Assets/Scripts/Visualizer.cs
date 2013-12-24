using UnityEngine;
using System.Collections;

public class Visualizer : MonoBehaviour
{
	public static int MaxDataVisualizeLength = 32;

	#region Public properties
	public enum Mode {
		Level,
		Spectrum,
		Data
	}

    public GameObject barPrefab;
	public Mode mode;
    
	#endregion

	#region Private members

	int barCount;

	#endregion

	#region MonoBehaviour

    void Update ()
    {
		float[] target = null;
		int targetLength = 0;

		switch(mode) {
		case Mode.Level:
			target = AudioJack.instance.ChannelLevels;
			targetLength = target.Length;
			break;
		case Mode.Spectrum:
			target = AudioJack.instance.BandLevels;
			targetLength = target.Length;
			break;
		case Mode.Data:
			target = AudioJack.instance.Data;
			targetLength = Mathf.Min (target.Length, MaxDataVisualizeLength);
			break;
		}

		if (barCount == targetLength)
            return;

        // Destroy the old bars.
        foreach (var child in transform)
            Destroy ((child as Transform).gameObject);

        // Change the number of bars.
		barCount = targetLength;
        var barWidth = 6.0f / barCount;
        var barScale = new Vector3 (barWidth * 0.9f, 1, 0.75f);

        // Create new bars.
        for (var i = 0; i < barCount; i++)
        {
            var x = 6.0f * i / barCount - 3.0f + barWidth / 2;
            var bar = Instantiate (barPrefab, transform.position + Vector3.right * x, transform.rotation) as GameObject;
            
			var controller = bar.GetComponent<BarController> ();
			controller.index = i;
			controller.mode = mode;

			bar.transform.parent = transform;
            bar.transform.localScale = barScale;
        }
    }

	#endregion
}
