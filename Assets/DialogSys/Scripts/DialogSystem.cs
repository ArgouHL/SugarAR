using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class DialogSystem : MonoBehaviour
{
    #region Singleton
    public static DialogSystem instance;
    private void SingletonInit()
    {

        if (instance != null)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }
    #endregion


    private Regex dialogueRegex = new(@"\[(?<EventTag>\w+)(?>\:(?<Settings>[\w,]*))?\](?<Content>[^\[]+)?", RegexOptions.Multiline);

    public TMP_Text nameField;
    public TMP_Text dialogField;
    public TextAsset[] dialogueTxts;

    private List<Dialogue> allDialogue = new();
    private Dictionary<string, int> unitIndexDict = new();
    private int tempIndex;

    public CharacterDatasManager characterDatas;
    public Dictionary<int, NpcSetting> npcDict = new();


    private bool dialogOpened = false;



    public CanvasGroup canvasGroup;
    public NPCActionManager nPCActionManager;

    private DialogInput inputActions;
    public delegate void DialogActions();
    public static DialogActions dialogAction;
    public static DialogActions closeDialogAction;
    public static DialogActions closeDialogAction_Once;


    private bool canClick = true;

    private void Awake()
    {
        SingletonInit();
        inputActions = new DialogInput();
        inputActions.Enable();       
        LoadDialogues();
        LoadAllNpcs();
        CloseDialog();
    }


    private void OnEnable()
    {
        inputActions.MoblieUI.Press.performed += OnClick;
        //  textAnimatorPlayer.onTextShowed.AddListener(() => isAllTextShow = true);
    }


    private void OnDisable()
    {
        inputActions.MoblieUI.Press.performed -= OnClick;
    }

    private void LoadDialogues()
    {
        allDialogue.Clear();
        unitIndexDict.Clear();
        foreach (var dialogueTxt in dialogueTxts)
        {
            var matches = dialogueRegex.Matches(dialogueTxt.text);
            foreach (Match match in matches)
            {
                if (!Enum.TryParse(match.Groups["EventTag"].Value, out DialogueTag dialogueTag))
                    continue;

                switch (dialogueTag)
                {
                    case DialogueTag.Start:
                        unitIndexDict.Add(match.Groups["Settings"].Value, allDialogue.Count);
                        break;

                    default:
                        allDialogue.Add(new Dialogue(dialogueTag, match.Groups["Settings"].Value.Split(','), match.Groups["Content"].Value.Replace("\\n", "\n")));

                        break;
                }


            }
        }
    }

    private void LoadAllNpcs()
    {
        npcDict.Clear();
        foreach (var npc in characterDatas.npcSettingObjs)
        {
            try
            {
                npcDict.Add(npc.npcSetting.index, npc.npcSetting);
            }
            catch
            {
                Debug.LogWarning(string.Format("Npc ID \"{0}\" is already exists.", npc.npcSetting.index));

            }
        }
    }

    private void CloseDialog()
    {
        dialogOpened = false;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
        closeDialogAction?.Invoke();
        closeDialogAction_Once?.Invoke();
        closeDialogAction_Once = null;
    }
    private void OpenDialog()
    {
        dialogOpened = true;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
    }


    public void StartDialog(string title)
    {
        if (!dialogOpened)
            OpenDialog();
        if (!unitIndexDict.ContainsKey(title))
        {
            Debug.LogWarning("Dialog key [" + title+"] not found");
            return;
        }

        tempIndex = unitIndexDict[title];
        SetDialog(ref tempIndex);

    }

    public void SetDialog(int tempIndex)
    {
        SetDialog(ref tempIndex);
    }

    public void SetDialog(ref int dialogueIndex)
    {
        Dialogue dialogue = allDialogue[dialogueIndex];
        switch (dialogue.tag)
        {
            case DialogueTag.End:
                CloseDialog();
                return;
            case DialogueTag.NPC:
                ShowNpc(dialogue);
                NextDialog();
                break;
            case DialogueTag.Sfx:
                NextDialog();
                break;
            case DialogueTag.Music:
                NextDialog();
                break;
            case DialogueTag.Button:
                NextDialog();
                break;
            case DialogueTag.Dialog:
                dialogField.text = dialogue.content;
                break;
            case DialogueTag.Action:
                DialogAction(dialogue);
                NextDialog();
                break;
            case DialogueTag.Setting:
                DialogSetting(dialogue);
                NextDialog();
                break;
            case DialogueTag.AutoNext:
                AutoToNextDialog(dialogue);
                NextDialog();
                break;
        }


    }

    private void AutoToNextDialog(Dialogue dialogue)
    {
        if(float.TryParse(dialogue.setting[0],out float duration))
        {
            LeanTween.delayedCall(duration, ()=>NextDialog());
        }     
    }

    private void DialogSetting(Dialogue content)
    {
       switch(content.setting[0])
        {
            case "NPC_On":
                nPCActionManager.NpcEnable(true);
                break;
            case "NPC_Off":
                nPCActionManager.NpcEnable(false);
                break;
            case "Click_Enable":
                canClick = true;
                break;
            case "Click_Disable":
                canClick = false;
                break;


        }
    }

    private void ShowNpc(Dialogue dialogue)
    {
        string npcName = "";
        if (dialogue.setting.Length <= 0)
        {
            Debug.LogWarning("Null NPC index");
        }
        else if (int.TryParse(dialogue.setting[0], out int npcIndex))
        {
            if (!npcDict.ContainsKey(npcIndex))
            {
                Debug.LogWarningFormat("NPC key \"{0}\" not found.", npcIndex);
            }
            else
            {
                NpcSetting npc = npcDict[npcIndex];
                npcName = npc.ShowName;
                if (npc.alternates.Length != 0)
                {
                    int alt = 0;
                    if (dialogue.setting.Length > 1 && int.TryParse(dialogue.setting[1], out int _alt))
                    {
                        alt = _alt;
                        Debug.Log(_alt);
                    }

                    if(dialogue.setting.Length > 2 && int.TryParse(dialogue.setting[1], out int motion))
                    {
                        nPCActionManager.ShowNPC(npc.index, alt, motion);
                    }    
                    else
                    {
                        nPCActionManager.ShowNPC(npc.index, alt);
                    }
                    
                }
                else
                {
                    nPCActionManager.GrayAllNPC();  
                }
               
            }
        }
        else
        {
            Debug.LogWarningFormat("NPC index \"{0}\" Error.", dialogue.setting[0]);
        }

        nameField.text = npcName;
    }

    public void NextDialog()
    {
        tempIndex++;
        SetDialog(tempIndex);
    }



    private void OnClick(InputAction.CallbackContext obj)
    {
        if (!canClick)
            return;
        NextDialog();
    }

    internal void EnableClick(bool b)
    {
        canClick = b;
    }

    private void DialogAction(Dialogue dialogue)
    {
        switch(dialogue.setting[0])
        {
            case "AR":
                Mainsys.instance.EnableAR(true);
                break;
        }
    }

}

[Serializable]
public struct Dialogue
{
    public DialogueTag tag;
    public string[] setting;
    public string content;

    public Dialogue(DialogueTag tag, string[] setting = null, string content = null)
    {
        this.tag = tag;
        this.setting = setting;
        this.content = content;
    }
}

public enum DialogueTag
{
    Start,
    End,
    NPC,
    Sfx,
    Music,
    Button,
    Dialog,
    Action,
    Setting,
    AutoNext
}



