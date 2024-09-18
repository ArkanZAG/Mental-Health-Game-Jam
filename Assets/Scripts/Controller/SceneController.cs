using UnityEngine;
using UnityEngine.SceneManagement;

namespace Controller
{
    public class SceneController : MonoBehaviour
    {
        public void ChangeScene(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}
