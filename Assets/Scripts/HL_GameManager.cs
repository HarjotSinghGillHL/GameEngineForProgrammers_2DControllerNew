using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HL_GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public enum EOverlays
    {
        OVERLAY_MENU = 0,
        OVERLAY_PAUSED,
        OVERLAY_INGAMEUI,
        OVERLAY_MAX,
    }

    public EOverlays CurrentOverlay = EOverlays.OVERLAY_MENU;

    public GameObject MainMenu;
    public GameObject PauseScreen;
    public GameObject InGameOverlay;
    public GameObject LocalPlayer;

    private HL_PlayerController LocalPlayerController;

    bool bPaused = false;
    void Start()
    {
        LocalPlayerController = LocalPlayer.GetComponent<HL_PlayerController>();
        LocalPlayerController.SetLocalPlayerState(false);
    }

    void UpdateOverlay(EOverlays Overlay)
    {
        CurrentOverlay = Overlay;
        MainMenu.SetActive(Overlay == EOverlays.OVERLAY_MENU);
        PauseScreen.SetActive(Overlay == EOverlays.OVERLAY_PAUSED);
        InGameOverlay.SetActive(Overlay == EOverlays.OVERLAY_INGAMEUI);

        GameObject Character = GameObject.Find("Character");


        if (Overlay == EOverlays.OVERLAY_INGAMEUI)
        {
            LocalPlayerController.SetLocalPlayerState(true);
        }
        else if (Overlay == EOverlays.OVERLAY_PAUSED)
        {
            LocalPlayerController.SetLocalPlayerState(true);
            LocalPlayerController.bPlayerControllerActive = false;
        }
        else
        {
            LocalPlayerController.SetLocalPlayerState(false);
        }

    }
    public void OnMenuLoad()
    {
        UpdateOverlay(EOverlays.OVERLAY_MENU);
    }
    public void OnLevelLoad()
    {
        UpdateOverlay(EOverlays.OVERLAY_INGAMEUI);
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
                    Cursor.visible = true;
                    break;
                }
                case EOverlays.OVERLAY_PAUSED:
                {
                    Cursor.visible = true;
                    break;
                }
                case EOverlays.OVERLAY_INGAMEUI:
                {
                    Cursor.visible = false;
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
