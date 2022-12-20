using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject LowHPEffect;
    private PlayerCtrl playerCtrl;
    private GlitchEffect glitchEffect;
    public Image HpImage;
    public Text Hptext;
    public Image HpIcon;
    public Sprite halfIcon;
    public Sprite lowIcon;
    private float maxHp;

    void Start()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
        glitchEffect = GetComponentInChildren<GlitchEffect>();
        maxHp = playerCtrl.MaxHp;
        LowHPEffect.SetActive(false);
    }

    void Update()
    {
        HpImage.fillAmount = playerCtrl.currHp/ maxHp;
        Hptext.text = "" + HpImage.fillAmount * 100 + "/100";
        if (playerCtrl.currHp <= 30)
        {
            HpIcon.sprite = lowIcon;
            glitchEffect.flipIntensity = 0f;
            glitchEffect.intensity = 0f;
            glitchEffect.colorIntensity = 0f;
            LowHPEffect.SetActive(true);
        }
    }
}
