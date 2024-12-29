using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;                   // Đối tượng xe (Player)
    private Vector3 thirdPersonOffset = new Vector3(0, 5, -7); // Vị trí camera góc nhìn thứ 3
    private Vector3 firstPersonOffset = new Vector3(0, 2, 0);  // Vị trí camera ghế lái
    private bool isThirdPersonView = true;      // Biến kiểm tra góc nhìn hiện tại

    // Update is called once per frame
    void LateUpdate()
    {
        // Chọn góc nhìn phù hợp dựa trên biến isThirdPersonView
        Vector3 currentOffset = isThirdPersonView ? thirdPersonOffset : firstPersonOffset;

        // Cập nhật vị trí của camera theo vị trí của player và offset
        transform.position = player.transform.position + currentOffset;

        // Nếu là góc nhìn thứ nhất, camera nên nhìn thẳng theo hướng của xe
        if (!isThirdPersonView)
        {
            transform.rotation = player.transform.rotation; // Góc nhìn theo hướng của xe
        }
    }

    void Update()
    {
        // Kiểm tra nếu người chơi nhấn phím "C" để chuyển đổi góc nhìn
        if (Input.GetKeyDown(KeyCode.C))
        {
            isThirdPersonView = !isThirdPersonView;
        }
    }
}
