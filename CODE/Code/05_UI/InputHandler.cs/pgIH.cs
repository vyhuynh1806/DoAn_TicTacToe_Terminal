using System;

class TicTacToeInput
{
    // Bảng cờ 3x3, lưu trạng thái từng ô ('X', 'O' hoặc ' ')
    static char[,] board = new char[3, 3]
    {
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' },
        { ' ', ' ', ' ' }
    };

    /// <summary>
    /// Hàm nhập tọa độ nước đi của người chơi.
    /// - ref int x, y: truyền tham chiếu, cho phép thay đổi giá trị bên ngoài.
    /// - Kiểm tra hợp lệ, không trùng ô, xử lý lỗi đầu vào.
    /// </summary>
    public static void GetMoveInput(ref int x, ref int y)
    {
        bool valid = false;

        while (!valid)
        {
            try
            {
                Console.Write("Nhập hàng (0-2): ");
                x = int.Parse(Console.ReadLine());

                Console.Write("Nhập cột (0-2): ");
                y = int.Parse(Console.ReadLine());

                //1. Kiểm tra phạm vi hợp lệ
                if (x < 0 || x > 2 || y < 0 || y > 2)
                {
                    Console.WriteLine("Vị trí nằm ngoài phạm vi bàn cờ! Vui lòng nhập lại.\n");
                }
                // 2. Kiểm tra trùng ô
                else if (board[x, y] != ' ')
                {
                    Console.WriteLine("Ô này đã được chọn! Hãy chọn ô khác.\n");
                }
                else
                {
                    // Nếu hợp lệ → thoát khỏi vòng lặp
                    valid = true;
                }
            }
            //3.  Bắt lỗi khi người chơi nhập sai định dạng
            catch (FormatException)
            {
                Console.WriteLine("Dữ liệu nhập không hợp lệ! Hãy nhập số nguyên (0, 1 hoặc 2).\n");
            }
        }
    }

    // Hàm Main để chạy thử nghiệm độc lập
    static void Main()
    {
        int row = 0, col = 0;

        Console.WriteLine("=== TIC TAC TOE - NHẬP NƯỚC ĐI ===");
        GetMoveInput(ref row, ref col);

        // Cập nhật bàn cờ
        board[row, col] = 'X';

        // Hiển thị kết quả
        Console.WriteLine($"\nBạn đã chọn ô: ({row}, {col})");
        Console.WriteLine("\nBàn cờ hiện tại:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
                Console.Write($" {board[i, j]} ");
            Console.WriteLine();
        }
    }
}


