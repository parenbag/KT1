using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TMP_Text scoreText;
    public TMP_Text timeText;

    public float baseValue = 10f;

    private float holdStartTime;
    private bool isHolding;

    private GameData data;
    private ISaveSystem saveSystem;


    // - 2
    private ResourceManager resourceManager;
    public Image buttonImage;

    //

    void Start()
    {
        saveSystem = new JsonSaveSystem();
        // saveSystem = new PlayerPrefsSaveSystem();

        data = saveSystem.Load();


        resourceManager = new ResourceManager(new ResourcesLoader());

        Sprite sprite = resourceManager.Load<Sprite>("Sprites/button");

        if (sprite != null)
        {
            buttonImage.sprite = sprite;
        }
    }

    void Update()
    {
        data.playTime += Time.deltaTime;
        UpdateUI();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        holdStartTime = Time.time;
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isHolding) return;

        float holdDuration = Time.time - holdStartTime;
        float gained = baseValue * holdDuration;

        data.score += gained;
        isHolding = false;

        saveSystem.Save(data);
    }

    void UpdateUI()
    {
        scoreText.text = $"Score: {data.score:F1}";
        timeText.text = $"Time: {data.playTime:F1}";
    }

    void OnApplicationQuit()
    {
        saveSystem.Save(data);

        if (buttonImage.sprite != null)
            resourceManager.Unload(buttonImage.sprite);
    }
    public void OnPointerDownUI()
    {
        holdStartTime = Time.time;
        isHolding = true;
    }

    public void OnPointerUpUI()
    {
        if (!isHolding) return;

        float holdDuration = Time.time - holdStartTime;
        float gained = baseValue * holdDuration;

        data.score += gained;
        isHolding = false;

        saveSystem.Save(data);
    }


}