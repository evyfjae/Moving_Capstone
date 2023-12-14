using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TextAreaSelectionHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public WorkbookSetting workbook;
    public TMP_InputField inputField;
    public TMP_Text dragText;
    public HyperLinkButton hyperLinkButton;
    public int line;
    private int startSelection, endSelection;
    private bool isDragging;
    public string hyperLinkText;
    
    void Update()
    {
        if (isDragging)
        {
            endSelection = inputField.stringPosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        startSelection = inputField.stringPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        int min = Mathf.Min(startSelection, endSelection);
        int max = Mathf.Max(startSelection, endSelection);

        if (max > inputField.text.Length)
        {
            max = inputField.text.Length;
        }

        string selectedText = inputField.text.Substring(min, max - min);
        Debug.Log("Selected Text: " + selectedText);
        hyperLinkText = selectedText;
        dragText.text = selectedText;
        hyperLinkButton.question_num = workbook.quest_num;
        hyperLinkButton.slide_num = workbook.slide_num;
        hyperLinkButton.line_num = line;

        // Check if the selected text is already colored
        if (selectedText.Contains("<color=#0000ff>"))
        {
            // Remove the color tags to reset to black
            selectedText = selectedText.Replace("<color=#0000ff>", "").Replace("</color>", "");
        }
        else if(selectedText != "")
        {
            // Add color tags to make the text blue
            selectedText = "<color=#0000ff>" + selectedText + "</color>";
        }

        // Update the text in the input field
        inputField.text = inputField.text.Substring(0, min) + selectedText + inputField.text.Substring(max);
    }
}
