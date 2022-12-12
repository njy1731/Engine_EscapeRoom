using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private PlayerCtrl playerCtrl;
    public Image HpImage;
    public Text Hptext;
    private int maxHp;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
        maxHp = playerCtrl.MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        HpImage.fillAmount = playerCtrl.currHp / maxHp;
        Hptext.text = "" + (HpImage.fillAmount * 100) + "/  100";
    }
}
