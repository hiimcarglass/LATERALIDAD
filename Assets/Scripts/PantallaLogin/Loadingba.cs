using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Loadingba : MonoBehaviour {

    public static Transform LoadingBar;
    public static Transform textNum;
    public static Transform textLoading;

    [SerializeField] private static float currentAmount;
    [SerializeField] private static float speed;


    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
    }

    public static void loadingBar()
    {
        if (currentAmount <= 100)
        {

            currentAmount += speed * Time.deltaTime;
            currentAmount = Mathf.Clamp(currentAmount, 0.0f, 100.0f);
            textNum.GetComponent<Text>().text = ((int)currentAmount).ToString() + "%";
            textLoading.gameObject.SetActive(true);

        }
        else
        {
            textLoading.gameObject.SetActive(false);
            textNum.GetComponent<Text>().text = "DONE !";
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
    }

		
}
