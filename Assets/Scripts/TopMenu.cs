using UnityEngine;

namespace SNAKE
{
    public class TopMenu : MonoBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
        }

        public void MaximizeWindow()
        {
            Screen.SetResolution(1920, 1080, FullScreenMode.MaximizedWindow);
        }

        public void MinimizeWindow()
        {
            Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
        }

        public void Mute()
        {
            AudioListener.volume = 0;
        }

        public void Unmute()
        {
            AudioListener.volume = 1;
        }
    }
}
