using UnityEngine;
using UnityEngine.EventSystems;

namespace guitar
{
    public class StrumButton : MonoBehaviour
    {
        void Start()
        {
            // Lock screen orientation to landscape
            Screen.orientation = ScreenOrientation.Landscape;
        }
    }
}
