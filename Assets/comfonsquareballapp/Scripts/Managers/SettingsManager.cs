using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    [SerializeField] Swither musicSwithcer;

    [Space(10)]
    [SerializeField] Swither soundsSwitcher;

    [Space(10)]
    [SerializeField] Swither vibraSwithcer;

    [Space(10)]
    [SerializeField] Color enable;
    [SerializeField] Color disable;

    public static bool VibraEnbled { get; set; } = true;
    public static bool SoundsEnabled { get; set; } = true;

    private void Start()
    {
        musicSwithcer.Switch(music.mute ? disable : enable, !music.mute);
        soundsSwitcher.Switch(SoundsEnabled ? enable : disable, SoundsEnabled);
        vibraSwithcer.Switch(VibraEnbled ? enable : disable, VibraEnbled);
    }

    public void SetMusicStatus()
    {
        music.mute = !music.mute;
        musicSwithcer.Switch(music.mute ? disable : enable, !music.mute);
    }

    public void SetSoundsStatus()
    {
        SoundsEnabled = !SoundsEnabled;
        soundsSwitcher.Switch(SoundsEnabled ? enable : disable, SoundsEnabled);
    }

    public void SetVibrationStatus()
    {
        VibraEnbled = !VibraEnbled;
        vibraSwithcer.Switch(VibraEnbled ? enable : disable, VibraEnbled);
    }
}
