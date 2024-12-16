using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main1 : MonoBehaviour
{
    [SerializeField] float money = 0.0f;      // ������� ������
    [SerializeField] float increment = 1.0f;  // �������� ���������� �� ����
    [SerializeField] float upgradeCost = 50.0f;   // ��������� ���������
    [SerializeField] float autoClickCost = 200.0f; // ��������� ���������

    private bool autoClickEnabled = false;    // ���� ��� ����-�����

    public TMP_Text upgradeAutoClick;  // ����� ��� ����������� ���� ���������
    public TMP_Text upgradeCostText;   // ����� ����������� ���� +1 �������
    public TMP_Text moneyText;         // UI ��� ����������� �����
    public GameObject upgradePanel;    // ������ ���������
    public Button upgradeButton;       // ������ ��� �������� ������
    public Button upgrade1Button;      // ������ "+1 Upgrade"
    public Button autoClickButton;     // ������ "Auto click"

    private void Start()
    {
        // ����������� ������ � �������
        upgradeButton.onClick.AddListener(ToggleUpgradePanel);
        upgrade1Button.onClick.AddListener(BuyUpgrade);
        autoClickButton.onClick.AddListener(BuyAutoClick);

        // �������� ������ ��� ������
        upgradePanel.SetActive(false);

        // ��������� ����� �����
        UpdateMoneyText();
        UpdateUpgradeCostText();
        UpdateUpgradeAutoClick();
    }

    // ������� ��� ����� �� �������� ������
    public void ButtonClick()
    {
        money += increment;
        UpdateMoneyText();
    }

    // ������� ��������� "+1 Upgrade"
    void BuyUpgrade()
    {
        if (money >= upgradeCost)
        {
            money -= upgradeCost;   // ������� ������
            increment += 1.0f;      // ����������� ����� �� ����
            upgradeCost *= 1.5f;    // ��������� ��������� ����� � ������� ���� ������
            UpdateMoneyText();
            UpdateUpgradeCostText();
        }
    }

    // ������� ���������
    void BuyAutoClick()
    {
        if (money >= autoClickCost && !autoClickEnabled)
        {
            money -= autoClickCost;  // ������� ������
            autoClickEnabled = true;
            InvokeRepeating("AutoClick", 1f, 1f); // ����-���� ������ �������
            UpdateMoneyText();
            UpdateUpgradeAutoClick();
        }
    }

    // ������� ��� ���������
    void AutoClick()
    {
        money += increment;
        UpdateMoneyText();
    }

    // ������������ ��������� ������ ���������
    void ToggleUpgradePanel()
    {
        upgradePanel.SetActive(!upgradePanel.activeSelf);
    }

    // ���������� ������ �����
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


