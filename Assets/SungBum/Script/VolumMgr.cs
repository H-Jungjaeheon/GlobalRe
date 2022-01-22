using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumMgr : MonoBehaviour
{
    [SerializeField]
    Slider BGMBar;

    [SerializeField]
    Slider SFXBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SoundMgr.In.SetVolumeBGM(BGMBar.value);
        SoundMgr.In.SetVolumeSFX(SFXBar.value);
    }
}
