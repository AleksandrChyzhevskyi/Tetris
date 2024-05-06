using Blacks.Interface;
using Game.Interface;
using Tetromino.Interface;
using UnityEngine;

namespace Game
{
    public class Place : IPlace
    {
        public int RotationIndex { get; private set; }
        public IBlockTile BlockTile { get; private set; }
        public Vector3Int Position { get; private set; }
        public Vector3Int[] Cells { get; private set; }

        public void Initialize(Vector3Int position, IBlockTile data, ITimerStep timer)
        {
            BlockTile = data;
            Position = position;

            SetCells(data);

            timer.UpdateStepTime();
            timer.SetLockTime(0f);

            RotationIndex = 0;
        }

        private void SetCells(IBlockTile data)
        {
            Cells ??= new Vector3Int[data.Position.Length];

            for (int i = 0; i < data.Position.Length; i++) 
                Cells[i] = data.Position[i].ToVector3Int();
        }

        public void SetRotationIndex(int index) =>
            RotationIndex = index;

        public void SetPosition(Vector3Int newPosition) =>
            Position = newPosition;
    }
}