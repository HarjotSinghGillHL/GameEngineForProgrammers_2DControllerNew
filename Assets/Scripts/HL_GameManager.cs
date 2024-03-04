using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum EOverlays
{
    OVERLAY_MENU = 0,
    OVERLAY_PAUSED,
    OVERLAY_INGAMEUI,
    OVERLAY_MAX,
}
public class HL_GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    EOverlays CurrentOverlay = EOverlays.OVERLAY_MENU;

    public GameObject MainMenu;
    public GameObject PauseScreen;
    public GameObject InGameOverlay;

    bool bPaused = false;
    void Start()
    {

    }

    void UpdateOverlay(EOverlays Overlay)
    {
        CurrentOverlay = Overlay;
        MainMenu.SetActive(Overlay == EOverlays.OVERLAY_MENU);
        PauseScreen.SetActive(Overlay == EOverlays.OVERLAY_PAUSED);
        InGameOverlay.SetActive(Overlay == EOverlays.OVERLAY_INGAMEUI);
    }
    public void OnMenuLoad()
    {
        UpdateOverlay(EOverlays.OVERLAY_MENU);
    }
    public void OnLevelLoad()
    {
        UpdateOverlay(EOverlays.OVERLAY_INGAMEUI);
    }
    public void LoadSceneEx(string SceneName)
    {
        SceneManager.LoadScene(SceneName);   
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            bPaused = !bPaused;

            if (bPaused)
                UpdateOverlay(EOverlays.OVERLAY_PAUSED);
            else
                UpdateOverlay(EOverlays.OVERLAY_INGAMEUI);
        }

        switch (CurrentOverlay)
        {
            case EOverlays.OVERLAY_MENU:
                {

                    break;
                }
                case EOverlays.OVERLAY_PAUSED:
                {
              
                    break;
                }
                case EOverlays.OVERLAY_INGAMEUI:
                {
                    break;
                }
            default:
                {
                    Application.Quit(); // How did this even end up like this?
                    break;
                }
        }
    }
}
