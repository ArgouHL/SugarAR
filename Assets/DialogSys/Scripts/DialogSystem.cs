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
    public CanvasGroup nameCanvasGroup;
    public RectTransform dialogRect;
    private bool dialogOpened = false;



    public CanvasGroup canvasGroup;
    public NPCActionManager nPCActionManager;

    private PhoneInput input => InputManager.instance.input;
    private Vector2 clickPos => input.Dialog.TouchPos.ReadValue<Vector2>();
    public float dialogCoolDown;

    public delegate void DialogActions();
    public static DialogActions dialogAction;
    public static DialogActions closeDialogAction;
    public static DialogActions closeDialogAction_Once;
    public static DialogActions onClickActions;
    public static DialogActions onEndActions;


    public CanvasGroup fakeNextBtn;
    private bool canClick = false;



    private void Awake()
    {
        SingletonInit();

        InputManager.instance.EnableInput(InputType.Dialog);
        LoadDialogues();
        LoadAllNpcs();
        CloseDialog();
    }


    private void OnEnable()
    {
        input.Dialog.Touch.performed += OnClick;
        //  textAnimatorPlayer.onTextShowed.AddListener(() => isAllTextShow = true);
    }


    private void OnDisable()
    {
        input.Dialog.Touch.performed -= OnClick;
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

    public void CloseDialog()
    {
        dialogOpened = false;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0;
        closeDialogAction?.Invoke();
        closeDialogAction_Once?.Invoke();
        closeDialogAction_Once = null;
        UnShowNpcName();
        InputManager.instance.DisableInput(InputType.Dialog);
    }
    private void OpenDialog()
    {
        dialogOpened = true;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1;
        InputManager.instance.EnableInput(InputType.Dialog);
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
                ShowDialog(dialogue.content);
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

    private void ShowDialog(string content)
    {

        if (canClick)
            LeanTween.delayedCall(dialogCoolDown, () => EnableClick(true));
        EnableClick(false);
        dialogField.text = content;
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
                EnableClick(true);
                break;
            case "Click_Disable":
                EnableClick(false);
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
                    ShowNpcName(npcName);
                }
                else
                {
                    UnShowNpcName();
                    nPCActionManager.GrayAllNPC();  
                }
               
            }
        }
        else
        {
            Debug.LogWarningFormat("NPC index \"{0}\" Error.", dialogue.setting[0]);
        }

      
    }

    private void ShowNpcName(string npcName)
    {
        nameCanvasGroup.alpha = 1;
        nameField.text = npcName;
    }

    private void UnShowNpcName()
    {
        nameCanvasGroup.alpha = 0;
    }

    public void NextDialog()
    {
        tempIndex++;
        SetDialog(tempIndex);
    }



    private void OnClick(InputAction.CallbackContext obj)
    {
        if (clickPos.y> dialogRect.rect.height) return;

        if (!canClick)
            return;
        NextDialog();
        onClickActions?.Invoke();
    }

    internal void EnableClick(bool b)
    {
        canClick = b;
        fakeNextBtn.alpha = b ? 1 : 0;
    }

    private void DialogAction(Dialogue dialogue)
    {
        switch(dialogue.setting[0])
        {
            case "AR":
                Mainsys.instance.EnableAR(true, dialogue.setting[1]);
                break;
            case "Scene":
                ChapterManager.LoadScene(dialogue.setting[1]);
                break;
        }
    }

    public void ShowHint(string hint)
    {
        UnShowNpcName();
        EnableClick(false);
        dialogField.text = hint ;
        OpenDialog();
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



