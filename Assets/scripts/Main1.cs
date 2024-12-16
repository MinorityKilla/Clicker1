using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main1 : MonoBehaviour
{
    [SerializeField] float money = 0.0f;      // Текущие деньги
    [SerializeField] float increment = 1.0f;  // Значение добавления за клик
    [SerializeField] float upgradeCost = 50.0f;   // Стоимость улучшения
    [SerializeField] float autoClickCost = 200.0f; // Стоимость автоклика

    private bool autoClickEnabled = false;    // Флаг для авто-клика

    public TMP_Text upgradeAutoClick;  // Текст для отображения цены автоклика
    public TMP_Text upgradeCostText;   // Текст отображения цены +1 апгрейд
    public TMP_Text moneyText;         // UI для отображения денег
    public GameObject upgradePanel;    // Панель улучшений
    public Button upgradeButton;       // Кнопка для открытия панели
    public Button upgrade1Button;      // Кнопка "+1 Upgrade"
    public Button autoClickButton;     // Кнопка "Auto click"

    private void Start()
    {
        // Привязываем методы к кнопкам
        upgradeButton.onClick.AddListener(ToggleUpgradePanel);
        upgrade1Button.onClick.AddListener(BuyUpgrade);
        autoClickButton.onClick.AddListener(BuyAutoClick);

        // Скрываем панель при старте
        upgradePanel.SetActive(false);

        // Обновляем текст денег
        UpdateMoneyText();
        UpdateUpgradeCostText();
        UpdateUpgradeAutoClick();
    }

    // Функция для клика по основной кнопке
    public void ButtonClick()
    {
        money += increment;
        UpdateMoneyText();
    }

    // Покупка улучшения "+1 Upgrade"
    void BuyUpgrade()
    {
        if (money >= upgradeCost)
        {
            money -= upgradeCost;   // Снимаем деньги
            increment += 1.0f;      // Увеличиваем доход за клик
            upgradeCost *= 1.5f;    // Следующее улучшение стоит в полтора раза больше
            UpdateMoneyText();
            UpdateUpgradeCostText();
        }
    }

    // Покупка автоклика
    void BuyAutoClick()
    {
        if (money >= autoClickCost && !autoClickEnabled)
        {
            money -= autoClickCost;  // Снимаем деньги
            autoClickEnabled = true;
            InvokeRepeating("AutoClick", 1f, 1f); // Авто-клик каждую секунду
            UpdateMoneyText();
            UpdateUpgradeAutoClick();
        }
    }

    // Функция для автоклика
    void AutoClick()
    {
        money += increment;
        UpdateMoneyText();
    }

    // Переключение видимости панели улучшений
    void ToggleUpgradePanel()
    {
        upgradePanel.SetActive(!upgradePanel.activeSelf);
    }

    // Обновление текста денег
    void UpdateMoneyText()
    {
        moneyText.text = money.ToString("F0") + "$";
    }

    void UpdateUpgradeCostText()
    {
        upgradeCostText.text = "UpgradeCost: " + upgradeCost.ToString("F0");
    }

    void UpdateUpgradeAutoClick()
    {
        upgradeAutoClick.text = "UpgradeCost: " + autoClickCost.ToString("F0");
    }
}


