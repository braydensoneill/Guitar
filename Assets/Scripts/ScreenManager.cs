using UnityEngine;
using UnityEngine.EventSystems;

namespace guitar
{
    public class ScreenManager : MonoBehaviour
    {
        void Start()
        {
            // Lock screen orientation to landscape
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}
