using UnityEngine;

public class Controller : MonoBehaviour {
    
    public GameObject playerGO;
    Player player;
    GameObject touchCheck = null;


    private void Start() {
        player = playerGO.GetComponent<Player>();
    }

    private void Update() {
        switch(SystemInfo.deviceType){
            case DeviceType.Desktop:
            DesktopController();
            break;
            case DeviceType.Handheld:
            AndroidController();
            break;
        }
    }

    void DesktopController(){
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            player.transform.position = new Vector3(
                player.transform.localPosition.x - player.movementSpeed * Time.deltaTime,
                player.transform.localPosition.y,
                0
            );
            return;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            player.transform.position = new Vector3(
                player.transform.localPosition.x + player.movementSpeed * Time.deltaTime,
                player.transform.localPosition.y,
                0
            );
            return;
        }
        if(Input.mousePresent){
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.transform.position = new Vector3(pos.x,
                player.transform.localPosition.y,
                0);
            return;
        }
    }

    void AndroidController(){
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Debug.Log(touch.phase);
            switch(touch.phase){
                case TouchPhase.Began:
                touchCheck = (GameObject)Instantiate(Resources.Load(
                    TouchCheck.PATH_PREFABS));
                touchCheck.transform.localPosition = Camera.main
                    .ScreenToWorldPoint(touch.position);
                player.transform.localPosition = new Vector2(touchCheck.transform.localPosition.x,
                    player.transform.localPosition.y);
                break;
                case TouchPhase.Moved:
                touchCheck.transform.localPosition = Camera.main
                    .ScreenToWorldPoint(touch.position);
                player.transform.localPosition = new Vector2(touchCheck.transform.localPosition.x,
                    player.transform.localPosition.y);
                break;
                case TouchPhase.Ended:
                Destroy(touchCheck);
                break;
            }
        }
    }
}