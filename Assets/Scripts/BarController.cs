using UnityEngine;
using System.Collections;

public class BarController : MonoBehaviour
{
    #region Public properties

    public int index;
    public bool spectrumMode;

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
		var levels = spectrumMode ? AudioJack.instance.OctaveBandSpectrum : AudioJack.instance.ChannelRmsLevels;

        if (index < levels.Length)
        {
            var level = levels [index];

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
    }

    #endregion
}
