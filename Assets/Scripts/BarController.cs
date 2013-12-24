using UnityEngine;
using System.Collections;

public class BarController : MonoBehaviour
{
    #region Public properties

    public int index;
    public Visualizer.Mode mode;

    #endregion

    #region Private members

    Renderer barRenderer;

    #endregion

    #region MonoBehaviour

    void Awake ()
    {
        barRenderer = GetComponentInChildren<Renderer> ();
    }

    void Update ()
    {
//		float[] levels = spectrumMode ? AudioJack.instance.BandLevels : AudioJack.instance.ChannelLevels;
		float[] levels = null;
		switch(mode) {
		case Visualizer.Mode.Level:
			levels = AudioJack.instance.ChannelLevels;
			break;
		case Visualizer.Mode.Spectrum:
			levels = AudioJack.instance.BandLevels;
			break;
		case Visualizer.Mode.Data:
			levels = AudioJack.instance.Data;
			break;
		}

		if( mode != Visualizer.Mode.Data ) {
			if (index < levels.Length) {
	            var level = levels [index];

				// band and spectrum
				if (level > 0.0f) {
					barRenderer.material.color = Color.red;
				} else if (level > -2.8f) {
					barRenderer.material.color = Color.yellow;
				} else{
					barRenderer.material.color = Color.green;
				}
				
				var vs = transform.localScale;
				vs.y = 3.0f * (1.0f + level / 30.0f);
				transform.localScale = vs;
			}
		} else {
			int sampleIndex = index * Mathf.FloorToInt((float)levels.Length / (float)Visualizer.MaxDataVisualizeLength);
			float level = levels[sampleIndex];

			barRenderer.material.color = Color.green;

			var vs = transform.localScale;
			vs.y = level;
			transform.localScale = vs;
		}
    }

    #endregion
}
