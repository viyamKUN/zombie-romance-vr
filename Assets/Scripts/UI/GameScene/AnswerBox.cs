using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ConversationModles;

public class AnswerBox : MonoBehaviour
{
    [SerializeField] private ConversationUI _conversationUI = null;
    [SerializeField] private Text _serifTextEN = null;
    [SerializeField] private Text _serifTextKR = null;
    bool _isCorrectAnswer = false;
    public void SetAnswerBox(bool isCorrect, Serif serif)
    {
        _isCorrectAnswer = isCorrect;
        _serifTextKR.text = serif.KR;
        _serifTextEN.text = serif.EN;
    }
    public void SelectThis()
    {
        GameManager.GM.EndConversation(_isCorrectAnswer);
    }
}
