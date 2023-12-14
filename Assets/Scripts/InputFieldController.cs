using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;
public class InputFieldController : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private TMP_InputField inputField;
    private Stack<string> undoStack;

    private bool isCtrlPressed = false;

    private void Start()
    {
        // InputField ������Ʈ�� ����
        inputField = GetComponent<TMP_InputField>();

        // Undo ���� �ʱ�ȭ
        undoStack = new Stack<string>();

        // �ʱ� ���¸� ���ÿ� �߰�
        undoStack.Push(inputField.text);
    }

    // �巡�� �̺�Ʈ �ڵ鷯
    public void OnDrag(PointerEventData eventData)
    {
        // �巡�� ���� �� ����Ǵ� �ڵ�
        if (inputField != null)
        {
            // �巡�� �߿��� �Է� �ʵ带 ������ �� ������ ����
            //inputField.interactable = false;
            Debug.Log("�巡����");
        }
    }

    // ������ �ٿ� �̺�Ʈ �ڵ鷯
    public void OnPointerDown(PointerEventData eventData)
    {
        // �����Ͱ� �ٿ�� �� ����Ǵ� �ڵ�
        if (inputField != null)
        {
            // �����Ͱ� �ٿ�� �� �Է� �ʵ带 ���� �����ϵ��� ����
            inputField.interactable = true;
        }
    }

    // Ű �Է� ����
    private void Update()
    {
        // Ctrl Ű ���� ������Ʈ
        isCtrlPressed = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        // Ctrl + C�� ������ ���õ� �ؽ�Ʈ�� ����
        if (isCtrlPressed && Input.GetKeyDown(KeyCode.C))
        {
            CopyTextToClipboard();
        }

        // Ctrl + V�� ������ Ŭ�������� ������ �ٿ��ֱ�
        if (isCtrlPressed && Input.GetKeyDown(KeyCode.V))
        {
            PasteTextFromClipboard();
        }

        // Ctrl + Z�� ������ ���� ���·� �ǵ�����
        if (isCtrlPressed && Input.GetKeyDown(KeyCode.Z))
        {
            Undo();
        }
    }

    // ���õ� �ؽ�Ʈ�� Ŭ�����忡 ����
    private void CopyTextToClipboard()
    {
        if (inputField != null)
        {
            GUIUtility.systemCopyBuffer = inputField.text;
        }
    }

    // Ŭ�������� ������ �ٿ��ֱ�
    private void PasteTextFromClipboard()
    {
        if (inputField != null)
        {
            inputField.text = GUIUtility.systemCopyBuffer;
        }
    }

    // ���� ���·� �ǵ�����
    private void Undo()
    {
        if (undoStack.Count > 1)
        {
            // ���� ���¸� ���ÿ��� ����
            undoStack.Pop();
            // ���� ���·� ���ư���
            inputField.text = undoStack.Peek();
        }
    }

    // �Է� �ʵ��� �ؽ�Ʈ ���� ����
    public void OnInputChange()
    {
        // �ؽ�Ʈ�� ����� ������ ���� ���¸� ���ÿ� �߰�
        undoStack.Push(inputField.text);
    }
}
