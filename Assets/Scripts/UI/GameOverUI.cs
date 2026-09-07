using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Runtime.InteropServices;
using UnityEngine;

public class GameOverUI : MonoBehaviour {

    [DllImport("__Internal")]
    private static extern void SendScoreToBrowser(int score);

    [SerializeField] private TextMeshProUGUI recipesDeliveredText;


    private void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (KitchenGameManager.Instance.IsGameOver()) {
            Show();
            int rawScore = DeliveryManager.Instance.GetScore();
            double a = 550;  // midpoint parameter
            double b = 2;    // curve steepness
            double scaledScore = 1000.0 * Mathf.Pow(rawScore, (float)b) / (Mathf.Pow(rawScore, (float)b) + Mathf.Pow((float)a, (float)b));
            int score = Mathf.RoundToInt((float)scaledScore);
            recipesDeliveredText.text = score.ToString();
#if UNITY_WEBGL && !UNITY_EDITOR
            SendScoreToBrowser(score);
#endif  
        } else {
            Hide();
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }


}