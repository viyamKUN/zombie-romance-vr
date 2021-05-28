using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConversationModles
{
    public class Conversation
    {
        public Serif AskSerif;
        public Serif GoodAnswer;
        public Serif WrongAnswer;
        public Conversation(string ask_kr, string ask_en, string goodAnswer_kr, string goodAnswer_en, string wrongAnswer_kr, string wrongAnswer_en)
        {
            this.AskSerif.KR = ask_kr;
            this.AskSerif.EN = ask_en;
            this.GoodAnswer.KR = goodAnswer_kr;
            this.GoodAnswer.EN = goodAnswer_en;
            this.WrongAnswer.KR = wrongAnswer_kr;
            this.WrongAnswer.EN = wrongAnswer_en;
        }
    }
    public struct Serif
    {
        public string KR;
        public string EN;
    }
}
