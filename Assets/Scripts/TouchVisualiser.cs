using UnityEngine;

public class TouchVisualiser : MonoBehaviour
{
    public GameObject touchIndicatorPrefab; // Prefab for the touch indicator
    public Canvas canvas; // Reference to the Canvas
    private GameObject[] touchIndicators;

    void Start()
    {
        touchIndicators = new GameObject[10]; // Supports up to 10 touches
        for (int i = 0; i < touchIndicators.Length; i++)
        {
            // Instantiate the prefab as a child of the Canvas
            touchIndicators[i] = Instantiate(touchIndicatorPrefab, canvas.transform);
            touchIndicators[i].SetActive(false);
        }
    }

    void Update()
    {
        int activeTouches = 0;

        // Handle touch inputs
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                UpdateIndicator(i, touch.position);
                activeTouches++;
            }
        }
        // Handle mouse input for testing on PC
        else if (Input.GetMouseButton(0)) // Left mouse button held
        {
            UpdateIndicator(0, Input.mousePosition);
            activeTouches = 1;
        }

        // Deactivate unused indicators
        for (int i = activeTouches; i < touchIndicators.Length; i++)
        {
            touchIndicators[i].SetActive(false);
        }
    }

    private void UpdateIndicator(int index, Vector2 screenPosition)
    {
        if (index >= touchIndicators.Length) return;

        // Convert screen position to UI position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            screenPosition,
            canvas.worldCamera,
            out Vector2 localPosition
        );

        touchIndicators[index].SetActive(true);
        touchIndicators[index].GetComponent<RectTransform>().anchoredPosition = localPosition;
    }
}
