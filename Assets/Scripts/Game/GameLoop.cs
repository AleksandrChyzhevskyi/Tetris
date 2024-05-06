using Blacks;
using Blacks.Interface;
using Game.Interface;
using Move;
using Move.Interface;
using StaticData;
using StaticData.Interface;
using Tetromino;
using Tetromino.Interface;
using UnityEngine;

namespace Game
{
    public class GameLoop : MonoBehaviour
    {
        public float StepDelay = 1f;
        public float LockDelay = 0.5f;
        public BoardPlain _boardPrefab;//переименовать убрать прифаб

        private IPlace _piece;
        private InputManager _input;
        private IMovement _movement;
        private IRotate _rotate;
        private ITimerStep _timer;
        private INewBoard _board;
        private INewGhost _ghost;
        private IStaticDataService _staticDataService;
        private INormalPosition _normalPosition;
        private IWallKicks _wallKicks;
        private IClear _clear;
        private ITileTetromino _tileTetromino;
        private IPosition _position;
        private INextTile _nextTile;

        private void Start()
        {
            _piece = new Place();
            _position = new NewPosition();
            _input = new InputManager();
            _wallKicks = new WallKicks();
            _normalPosition = new NormalPosition();

            _timer = new TimerStep(StepDelay, LockDelay);
            _tileTetromino = new TileTetromino(_boardPrefab.Map, _piece);
            _nextTile = new NextTile(_tileTetromino, _boardPrefab);
            _staticDataService = new StaticDataService(_normalPosition, _wallKicks);

            _board = new NewBoard(_boardPrefab.Map, _staticDataService.GetBlockTiles(), _timer, _piece, _boardPrefab.Grid.size, _tileTetromino, _position, _nextTile);
            _ghost = new NewGhost(_boardPrefab.ShadowMap, _boardPrefab.TileShadow, _board, _piece, _tileTetromino, _position);
            
            _clear = new Clear(_board, _tileTetromino, _position);

            _movement = new Movement(_board, _piece, _timer, _clear, _position, _tileTetromino);
            _rotate = new Rotate(_piece, _movement, _wallKicks);
        }

        private void Update()
        {
            _tileTetromino.Clear();

            _timer.UpdateLockTime();

            _input.InputUpdate(_movement, _rotate);

            if (_timer.CheckStepTime())
                _movement.Step();

            _tileTetromino.Set();

            _ghost.UpdatePosition();
        }
    }
}