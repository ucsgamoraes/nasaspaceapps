using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HeneGames.DialogueSystem
{
    public class DialogueEvents : MonoBehaviour
    {
        public DialogueManager dialogManager;

        void StartDialog()
        {
            dialogManager.Teste();
        }
    }
}