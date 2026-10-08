using UnityEngine;
using UnityEngine.InputSystem;
//===============================
//戦車のコントロールクラス
//===============================
public class Tank : MonoBehaviour
{
    [Header("===オブジェクト参照===")]
    [SerializeField] private Transform topJoint;
    [SerializeField] private Transform cannonJoint;

    private Vector3 topAngles = Vector3.zero;

    private Vector3 cannonAngles = Vector3.zero;

    public GameObject bulletPrefab;
    public Transform shotPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed == true)
        {
            transform.Translate(transform.forward * 5 * Time.deltaTime);
        }
        if (Keyboard.current.sKey.isPressed == true)
        {
            transform.Translate(transform.forward * -5 * Time.deltaTime);
        }
        if(Keyboard.current.aKey.isPressed == true)
        {
            transform.Rotate(Vector3.up * -90 * Time.deltaTime);
        }
        if(Keyboard.current.dKey.isPressed == true)
        {
            transform.Rotate(Vector3.up * 90 * Time.deltaTime);
        }

        //マウスの移動量を取得する
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();
        topAngles.y += mouseDelta.x * 0.1f;
        cannonAngles.x -= mouseDelta.y * 0.1f;
        cannonAngles.x = Mathf.Clamp(cannonAngles.x, -10f, 30f);

        topJoint.localEulerAngles = topAngles;
        cannonJoint.localEulerAngles = cannonAngles;

        if (Mouse.current.leftButton.wasPressedThisFrame == true)
        { 

            GameObject bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
            bullet.GetComponent<Rigidbody>()
                .AddForce(shotPoint.forward * 25f, ForceMode.Impulse);

            Destroy(bullet, 5f);


        }

    }
}
