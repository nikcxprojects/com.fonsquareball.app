using UnityEngine;
using UnityEngine.UI;

public class Swither : MonoBehaviour
{
    [SerializeField] Image back;
    [SerializeField] Transform knob;

    public void Switch(Color color, bool enable)
    {
        back.color = color;
        knob.localPosition = enable ? new Vector2(26.0f, 0) : new Vector2(-26.0f, 0);
    }
}
