using System.Collections.Generic;  // Add this to avoid the CS0246 error
using UnityEngine;
using UnityEngine.UI;

public class DebugManager : MonoBehaviour
{
    // List of GameObjects to manage
    public List<GameObject> buttonGroups;

    // Single boolean to control visibility for all buttons
    public bool showButtonHitboxes = true;

    // OnValidate is called in the editor whenever a value is changed
    void OnValidate()
    {
        // Update all button groups based on the single boolean
        for (int i = 0; i < buttonGroups.Count; i++)
        {
            UpdateButtonGroupVisibility(buttonGroups[i], showButtonHitboxes);
        }
    }

    // Method to update the visibility of buttons directly under a GameObject
    private void UpdateButtonGroupVisibility(GameObject group, bool show)
    {
        if (group == null) return;

        // Find all children with the name "Button"
        Transform[] buttonTransforms = group.GetComponentsInChildren<Transform>(true);
        
        foreach (var buttonTransform in buttonTransforms)
        {
            // Check if the object has the name "Button"
            if (buttonTransform.name == "Button")
            {
                // Get RawImage component from the button-like object
                RawImage buttonRawImage = buttonTransform.GetComponent<RawImage>();

                if (buttonRawImage != null)
                {
                    // Set the opacity to 100/255 when not fully visible
                    Color currentColor = buttonRawImage.color;
                    currentColor.a = show ? 0.3f : 0f;  // Set alpha to 100/255 when not showing
                    buttonRawImage.color = currentColor;

                    // Optionally, disable other visual components (like text) if needed
                    Text buttonText = buttonTransform.GetComponentInChildren<Text>();
                    if (buttonText != null)
                    {
                        buttonText.enabled = show;  // Disable text when the button is not visible
                    }
                }
            }
        }
    }
}
