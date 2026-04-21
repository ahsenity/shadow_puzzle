using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class son : MonoBehaviour
{
    int toplamhayvan = 3;
    int ilk_hayvan = 0;
   public void level_son()
    {  
        ilk_hayvan++;
        if (ilk_hayvan == toplamhayvan)
        {
            Debug.Log("OYUN BITTI");
            
            StartCoroutine(GecisYap("puzzle_sahnesi", 1f));

        }

    }

    IEnumerator GecisYap(string sahneAdi, float beklemeSuresi)
    {
        yield return new WaitForSeconds(beklemeSuresi);

        SceneManager.LoadScene(sahneAdi);
    }

}
