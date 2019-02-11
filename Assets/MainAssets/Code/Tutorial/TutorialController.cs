using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public int currentTutorialStep;

    public CanvasGroup commanderPanel, responsePanel;

    public TextMeshProUGUI[] responsesText;
    public TextMeshProUGUI commanderText;

    public GameObject fingerCircle;

    private int currentCommander, currentResponse;

    private bool rotationTutorialOn;

    private void Start()
    {
        currentTutorialStep = 0;
        currentCommander = 0;
        currentResponse = 0;

        rotationTutorialOn = false;
    }

    public void NextStep()
    {
        currentTutorialStep++;
    }

    public void Update()
    {
        commanderText.text = commanderTexts[currentCommander];
        for (int i = 0; i < responsesText.Length; i++)
        {
            responsesText[i].text = responseTexts[currentResponse][i];
        }

        switch (currentTutorialStep)
        {
            case 0:
                currentCommander = 0;
                currentResponse = 0;
                break;
            case 1:
                currentCommander = 1;
                currentResponse = 1;
                break;
            case 2:
                currentCommander = 2;
                currentResponse = 2;
                break;
            case 3:
                currentCommander = 3;
                Hide(responsePanel);

                ShowCircle();
                rotationTutorialOn = true;
                break;
            case 4:
                currentCommander = 4;
                break;
            case 5:
                Show(responsePanel);
                currentCommander = 5;
                currentResponse = 3;
                break;
            case 6:
                currentCommander = 6;
                Hide(responsePanel);
                break;
            case 7:
                currentCommander = 7;
                break;
            case 8:
                currentCommander = 8;
                break;
        }

        if (rotationTutorialOn)
        {
            CountRotation();
            if (nrOfRotations > 0)
            {
                currentTutorialStep++;
                rotationTutorialOn = false;
                HideCircle();
            }
        }
    }

    private void Hide(CanvasGroup panel)
    {
        panel.alpha = 0;
        panel.blocksRaycasts = false;
        panel.interactable = false;
    }

    private void Show(CanvasGroup panel)
    {
        panel.alpha = 1;
        panel.blocksRaycasts = true;
        panel.interactable = true;
    }

    #region shooting tutorial

    #endregion

    #region rotating tutorial
    private float totalRotation = 0;
    public int nrOfRotations
    {
        get
        {
            return Mathf.Abs(((int)totalRotation) / 360);
        }
    }

    private Vector3 lastPoint;

    private void ShowCircle()
    {
        fingerCircle.SetActive(true);
        fingerCircle.GetComponent<Animator>().SetBool("isCircle", true);
        GameController.instance.player.GetComponent<Animator>().SetBool("isCircling", true);
    }

    private void HideCircle()
    {
        fingerCircle.SetActive(false);
    }

    private void CountRotation()
    {
        Vector3 facing = GameController.instance.player.transform.TransformDirection(Vector3.up);
        facing.z = 0;

        float angle = Vector3.Angle(lastPoint, facing);
        if (Vector3.Cross(lastPoint, facing).z < 0)
            angle *= -1;

        totalRotation += angle;
        lastPoint = facing;
    }
    #endregion

    #region Text

    private string[] commanderTexts = new string[]
    {
        "Captain Webb? Captain Webb? Please acknowledge if you're receiving this.",
        "Oh thank god. All of the other hive ships have been abandoned! Are you ok?",
        "Wonderful! I'm getting some diagnostics that say your flight movement system is down, is everything else fine?",
        "Ok, ok, we'll run a quick diagnostic. Uhm, first, can you still rotate fine?",
        "Perfect, ok, can you still shoot?",
        "Ok wonderful. I'm getting a lot of local static can you see any other ships?",
        "I'm getting no life scans. It's an empty ship, can you dispose of it?",
        "Oh no! They must have left their hive commands enabled. We're going to port you over to some locations, please dispose of any ships you see.",
    };

    private List<string[]> responseTexts = new List<string[]>
    {
        new string[]
        {
            "Acknowledged, Captain Webb here.",
            "Who is this?",
            "Yeah, what up?"
        },

        new string[]
        {
            "I'm ok, I think.",
            "What do you mean abandoned?",
            "Everything is chilli dog."
        },

        new string[]
        {
            "I don't know? Maybe?",
            "What do you mean my movement system is down!",
            "The fridge works, does that count?"
        },

        new string[]
        {
            "Affirmative.",
            "Yes, are they hostile?",
            "Probably."
        }
    };

    #endregion

}
