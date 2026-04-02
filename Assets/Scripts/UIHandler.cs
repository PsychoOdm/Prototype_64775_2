using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler : MonoBehaviour
{
    private VisualElement m_Healthbar;
    public static UIHandler instance { get; private set; }
    public float displayTime = 4.0f;
    public VisualElement m_NonPlayerDialogue;
        public VisualElement m_NonPlayerBackground;

    private float m_TimerDisplay;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        m_Healthbar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        SetHealthValue(1.0f);

           m_NonPlayerBackground = uiDocument.rootVisualElement.Q<VisualElement>("Background");
        m_NonPlayerBackground.style.display = DisplayStyle.None;

        m_NonPlayerDialogue = uiDocument.rootVisualElement.Q<VisualElement>("NPCDialogue");
        m_NonPlayerDialogue.style.display = DisplayStyle.None;
        m_TimerDisplay = -1.0f;
    }

    private void Update()
    {
        if (m_TimerDisplay > 0)
        {
            m_TimerDisplay -= Time.deltaTime;

            if (m_TimerDisplay < 0)
            {
                Debug.Log("UIHandler: Update: Hiding dialogue");
                m_NonPlayerBackground.style.display = DisplayStyle.None;
                m_NonPlayerDialogue.style.display = DisplayStyle.None;
            }
        }
    }

    public void SetHealthValue(float percentage)
    {
        m_Healthbar.style.width = Length.Percent(55 * percentage);
    }

    public void DisplayDialogue()
    {
        Debug.Log("UIHandler: DisplayDialogue");

        m_NonPlayerBackground.style.display = DisplayStyle.Flex;


        m_NonPlayerDialogue.style.display = DisplayStyle.Flex;
        m_TimerDisplay = displayTime;
    }
}