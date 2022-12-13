using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class HealthBar : MonoBehaviour
{
    private PlayerCtrl playerCtrl;
    private GlitchEffect glitchEffect;
    public Image HpImage;
    public Text Hptext;
    public Image HpIcon;
    public Sprite halfIcon;
    public Sprite lowIcon;
    private float maxHp;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
        glitchEffect = GetComponentInChildren<GlitchEffect>();
        maxHp = playerCtrl.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        HpImage.fillAmount = playerCtrl.currHp/ maxHp;
        Hptext.text = "" + HpImage.fillAmount * 100 + "/100";

        if(playerCtrl.currHp <= 50)
        {
            HpIcon.sprite = halfIcon;
            glitchEffect.flipIntensity = 0.5f;
            glitchEffect.intensity = 0.5f;
            glitchEffect.colorIntensity = 0.5f;

        }
        if(playerCtrl.currHp <= 10)
        {
            HpIcon.sprite = lowIcon;
            glitchEffect.flipIntensity = 0.8f;
            glitchEffect.intensity = 0.8f;
            glitchEffect.colorIntensity = 0.8f;
        }
    }
}
