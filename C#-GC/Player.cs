using System.Drawing;

internal class Player
{
    char _buffer;
    string _map;
    int _size;
    int _playerX;
    int _playerY;

    public Player(string map, int size, int playerX, int playerY)
    {
        _map = map;
        _size = size;
        _playerX = playerX;
        _playerY = playerY;
    }

    public void Input(Bitmap img)
    {
        int x;
        int y;
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.Z:
                    (x, y) = (0, -1);
                    break;
                case ConsoleKey.S:
                    (x, y) = (0, 1);
                    break;
                case ConsoleKey.Q:
                    (x, y) = (-1, 0);
                    break;
                case ConsoleKey.D:
                    (x, y) = (1, 0);
                    break;
                default:
                    continue;
            }


            if (IfNoObstacle(_playerX + x, _playerY + y))
            {
                ReplaceOldCase(_playerX, _playerY);
                Move(x, y);
            }

        } while (true);
    }

    private void Move(int x, int y)
    {
        _playerX += x;
        _playerY += y;
        Console.SetCursorPosition(_playerX, _playerY);
        Console.Write("P");
    }
    private bool IfNoObstacle(int x, int y)
    {

        _buffer = _map[y * _size + x];
        if(_buffer == '#')
        {
            return false;
        }
        return true;
    }

    private void ReplaceOldCase(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(_buffer);
    }
}
