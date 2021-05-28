using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConversationModles;

public class ConversationUI : MonoBehaviour
{
    [SerializeField] private Text _answerTextKo = null;
    [SerializeField] private Text _answerTextEn = null;
    [SerializeField] private AnswerBox[] _answerBoxes = null;
    public void SetConversationUI(Conversation conversation)
    {
        _answerTextKo.text = conversation.AskSerif.KR;
        _answerTextEn.text = conversation.AskSerif.EN;
        int correctNumber = Random.Range(0, 2);
        int incorrectNumber = (correctNumber == 0) ? 1 : 0;
        _answerBoxes[correctNumber].SetAnswerBox(true, conversation.GoodAnswer);
        _answerBoxes[incorrectNumber].SetAnswerBox(false, conversation.WrongAnswer);
    }
}
