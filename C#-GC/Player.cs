using System.Drawing;

internal class Player
{
    char _buffer;
    string _map;
    int _size;
    public int playerX = 10;
    public int playerY = 10;

    public Player(string map, int size)
    {
        _map = map;
        _size = size;
    }

    public void Input(Bitmap img, int x, int y)
    {
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

            int newX = playerX + x;
            int newY = playerY + y;

            if (IsObstacle(newX, newY) == false)
            {
                SetBack(playerX, playerY);
                Move(x, y);
            }

        } while (true);
    }

    private void Move(int x, int y)
    {
        playerX += x;
        playerY += y;
        Console.SetCursorPosition(playerX, playerY);
        Console.Write("P");
    }

    private bool IsObstacle(int x, int y)
    {
        return _map[y * _size + x] == '#';
    }

    private void SetBack(int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(_map[y * _size + x]);
    }
}
