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
        // InputField 컴포넌트에 접근
        inputField = GetComponent<TMP_InputField>();

        // Undo 스택 초기화
        undoStack = new Stack<string>();

        // 초기 상태를 스택에 추가
        undoStack.Push(inputField.text);
    }

    // 드래그 이벤트 핸들러
    public void OnDrag(PointerEventData eventData)
    {
        // 드래그 중일 때 실행되는 코드
        if (inputField != null)
        {
            // 드래그 중에는 입력 필드를 수정할 수 없도록 설정
            //inputField.interactable = false;
            Debug.Log("드래그중");
        }
    }

    // 포인터 다운 이벤트 핸들러
    public void OnPointerDown(PointerEventData eventData)
    {
        // 포인터가 다운될 때 실행되는 코드
        if (inputField != null)
        {
            // 포인터가 다운될 때 입력 필드를 수정 가능하도록 설정
            inputField.interactable = true;
        }
    }

    // 키 입력 감지
    private void Update()
    {
        // Ctrl 키 상태 업데이트
        isCtrlPressed = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        // Ctrl + C를 누르면 선택된 텍스트를 복사
        if (isCtrlPressed && Input.GetKeyDown(KeyCode.C))
        {
            CopyTextToClipboard();
        }

        // Ctrl + V를 누르면 클립보드의 내용을 붙여넣기
        if (isCtrlPressed && Input.GetKeyDown(KeyCode.V))
        {
            PasteTextFromClipboard();
        }

        // Ctrl + Z를 누르면 이전 상태로 되돌리기
        if (isCtrlPressed && Input.GetKeyDown(KeyCode.Z))
        {
            Undo();
        }
    }

    // 선택된 텍스트를 클립보드에 복사
    private void CopyTextToClipboard()
    {
        if (inputField != null)
        {
            GUIUtility.systemCopyBuffer = inputField.text;
        }
    }

    // 클립보드의 내용을 붙여넣기
    private void PasteTextFromClipboard()
    {
        if (inputField != null)
        {
            inputField.text = GUIUtility.systemCopyBuffer;
        }
    }

    // 이전 상태로 되돌리기
    private void Undo()
    {
        if (undoStack.Count > 1)
        {
            // 현재 상태를 스택에서 제거
            undoStack.Pop();
            // 이전 상태로 돌아가기
            inputField.text = undoStack.Peek();
        }
    }

    // 입력 필드의 텍스트 변경 감지
    public void OnInputChange()
    {
        // 텍스트가 변경될 때마다 현재 상태를 스택에 추가
        undoStack.Push(inputField.text);
    }
}
