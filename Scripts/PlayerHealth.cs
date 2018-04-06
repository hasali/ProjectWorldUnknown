using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public const int maxHealth = 150;
    public static int currentHealth = maxHealth;
    public RectTransform healthBar;

    public Image damageImage;
    public float flashSpeed;
    public Color flashColour = new Color(1.0f, 0.0f, 0.0f);
	Color transparent = new Color(1.0f, 0.0f, 0.0f, 0.0f);

    //private static bool isDamaged = false;

    private static int almostDead = 50;

    public static void TakeDamage(int amount)
    {
        //isDamaged = true;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
			GAMEMgr.instance.isPlayerDead = true;
            
            UIMgr ePanel = UIMgr.instance;
            if (ePanel != null)
            {
                ePanel.enableEndUI();
                //			enemiesDestroyedVal = GameObject.Find ("EnemiesDestroyedVal").GetComponentInChildren<Text>(true);
                //            enemiesDestroyedVal.text = GAMEMgr.instance.score.ToString();
            }
          // Time.timeScale = 0.0f;
        }

       
    }

	public void reset(){
		currentHealth = maxHealth;
		damageImage.color = transparent;
		GAMEMgr.instance.resetGame ();
	}

    public void updatePlayerHealth()
    {
        //healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);

        if (/*isDamaged && */currentHealth <= almostDead)
        {
            damageImage.color = flashColour;
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        //else
        //{
        //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        //}

        //isDamaged = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        updatePlayerHealth();
	} 
}
