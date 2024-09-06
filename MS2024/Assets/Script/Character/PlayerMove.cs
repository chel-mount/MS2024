using Fusion;
using UnityEngine;

public class PlayerMove : NetworkBehaviour
{    
    private NetworkCharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<NetworkCharacterController>();
    }
        
    public override void FixedUpdateNetwork()
    {
        if (Object.HasStateAuthority)
        {
            var inputDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
            // 入力方向を移動方向としてそのまま渡す
            characterController.Move(inputDirection);
        }
    }
}
