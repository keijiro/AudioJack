using UnityEngine;
using System.Collections;

public class Visualizer : MonoBehaviour
{
	#region Public properties

    public GameObject barPrefab;
	public bool spectrumMode;
    
	#endregion

	#region Private members

	int barCount;

	#endregion

	#region MonoBehaviour

    void Update ()
    {
		var target = spectrumMode ? AudioJack.instance.BandLevels : AudioJack.instance.ChannelLevels;

        if (barCount == target.Length)
            return;

        // Destroy the old bars.
        foreach (var child in transform)
            Destroy ((child as Transform).gameObject);

        // Change the number of bars.
        barCount = target.Length;
        var barWidth = 6.0f / barCount;
        var barScale = new Vector3 (barWidth * 0.9f, 1, 0.75f);

        // Create new bars.
        for (var i = 0; i < barCount; i++)
        {
            var x = 6.0f * i / barCount - 3.0f + barWidth / 2;
            var bar = Instantiate (barPrefab, transform.position + Vector3.right * x, transform.rotation) as GameObject;
            
			var controller = bar.GetComponent<BarController> ();
			controller.index = i;
			controller.spectrumMode = spectrumMode;

			bar.transform.parent = transform;
            bar.transform.localScale = barScale;
        }
    }

	#endregion
}
