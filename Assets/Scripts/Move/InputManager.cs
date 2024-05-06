using Move.Interface;
using UnityEngine;

namespace Move
{
    public class InputManager : MonoBehaviour
    {
        public void InputUpdate(IMovement movement, IRotate rotate)
        {
            if (Input.GetKeyDown(KeyCode.A))
                movement.Move(Vector2Int.left);
            else if (Input.GetKeyDown(KeyCode.D))
                movement.Move(Vector2Int.right);

            if (Input.GetKeyDown(KeyCode.S))
                movement.Move(Vector2Int.down);

            if (Input.GetKeyDown(KeyCode.Q))
                rotate.RotateBlock(Vector2Int.down.y);

            else if (Input.GetKeyDown(KeyCode.E))
                rotate.RotateBlock(Vector2Int.up.y);

            if (Input.GetKeyDown(KeyCode.Space))
                movement.HardDrop();
        }
    }
}