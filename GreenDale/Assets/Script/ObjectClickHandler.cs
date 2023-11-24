using UnityEngine;
using Fungus;

public class ObjectClickHandler : MonoBehaviour
{
    private Flowchart flowchart;
    private int maxDialogueCount = 3; // 최대 대화 횟수 설정

    private void Start()
    {
        // Fungus Flowchart 찾기
        flowchart = GetComponent<Flowchart>();
    }

    private void Update()
    {
        // 대화 횟수 변수 가져오기
        int dialogueCount = flowchart.GetIntegerVariable("DialogueCount");
        Debug.Log(dialogueCount);

        // 대화 횟수가 최대 횟수 미만일 때만 클릭 이벤트 실행
        if (dialogueCount < maxDialogueCount)
        {
            // 클릭 이벤트에 대한 Fungus 메시지 전송
            flowchart.SendFungusMessage("ObjectClicked");

            // 대화 횟수 증가
            flowchart.SetIntegerVariable("DialogueCount", dialogueCount + 1); // 수정된 부분
        }
        else
        {
            // 최대 대화 횟수에 도달했을 때의 처리 추가
            Debug.Log("최대 대화 횟수에 도달했습니다.");
        }
    }
}
