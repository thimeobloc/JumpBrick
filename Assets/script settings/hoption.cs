using UnityEngine;
using UnityEngine.SceneManagement;

public class hoption : MonoBehaviour
{
        public void hoptiononClick()
        {
            SceneManager.LoadScene("setting");
            Debug.Log("setting Button Press");
        }
}
