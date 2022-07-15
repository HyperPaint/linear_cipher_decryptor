using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace decryptor
{
    public partial class decryptor : Form
    {
        public decryptor()
        {
            InitializeComponent();
        }

        private string text;
        private const string FILE_LOAD_OK = "*** Файл загружен ***\n";
        private const string FILE_LOAD_ERROR = "*** Файл не загружен ***\n";
        private const string ERROR = "-1";
        private const string ERROR_ = "\n*** Кракен съел программу ***\n";

        private bool loadTextFromFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files|*.txt|All files|*.*";
            ofd.InitialDirectory = "./";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                text = File.ReadAllText(ofd.FileName);
                outText.AppendText(FILE_LOAD_OK);
                outText.AppendText(text + "\n");
                return true;
            }
            else
            {
                outText.AppendText(FILE_LOAD_ERROR);
                return false;
            }
        }

        private void selectFile_Click(object sender, EventArgs e)
        {
            if (loadTextFromFile())
            {
                decrypt.Enabled = true;
            }
            
        }

        private int alphabetLength;
        private int alphabetLengthForCheck;
        private string alphabet;
        private string alphabetFrequency;
        private const string alphabetFrequencyRu = "оеаинтсрвлкмдпуяызьъбгчйхжюшцщэф";
        private const string alphabetFrequencyEn = "etaoinshrdlcumwfgypbvkxjqz";

        private const string DECRYPTOR_START = "\n*** Начало ***\n";
        private const string DECRYPTOR_END = "\n*** Конец ***\n";
        private const string TEXT_CHECK = "\n*** Проверка соответствия текста алфавиту ***\n";
        private const string TEXT_CHECK_OK = "\n*** Текст соответствует алфавиту ***\n";
        private const string TEXT_CHECK_ERROR = "\n*** Текст не соответствует алфавиту ***\n";

        private void decryptorProcess()
        {
            // задание алфавита
            if (alphabetRu.Checked)
            {
                alphabetLength = 32;
                alphabetLengthForCheck = alphabetLength;
                alphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
                alphabetFrequency = alphabetFrequencyRu;
            }
            else if (alphabetEn.Checked)
            {
                alphabetLength = 26;
                alphabetLengthForCheck = alphabetLength;
                alphabet = "abcdefghijklmnopqrstuvwxyz";
                alphabetFrequency = alphabetFrequencyEn;
            }
            else if (alphabetBinary.Checked)
            {
                alphabetLength = 2;
                alphabetLengthForCheck = 12;
                alphabet = "0123456789" + Convert.ToChar(10) + Convert.ToChar(13);
            }

            // проверка
            outText.AppendText(TEXT_CHECK);
            bool buff;
            for (int a = 0; a < text.Length; a++)
            {
                buff = false;
                for (int b = 0; b < alphabetLengthForCheck; b++)
                {
                    if (text[a] == alphabet[b])
                    {
                        buff = true;
                        break;
                    }
                }
                
                if (!buff)
                {
                    outText.AppendText(TEXT_CHECK_ERROR);
                    outText.AppendText("Символ " + text[a] + " с кодом : " + ((int)text[a]).ToString());
                    return;
                }
            }
            outText.AppendText(TEXT_CHECK_OK);

            outText.AppendText(DECRYPTOR_START);
            try
            {
                // частотный анализ
                if (decryptType.GetItemChecked(0))
                {
                    frequencyAnalysis();
                }
                // линейный шифр
                if (decryptType.GetItemChecked(1))
                {
                    linearCrypt();
                }
                // потоковый шифр
                if (decryptType.GetItemChecked(2))
                {
                    streamCrypt();
                }
            }
            catch (Exception e)
            {
                outText.AppendText(ERROR_);
                outText.AppendText(e.Message + "\n");
            }

            outText.AppendText(DECRYPTOR_END);
        }

        private const string FREQUENCY_ANALISIS = "\n*** Частотный анализ ***\n";
        private const string LINEAR_CRYPT = "\n*** Линейный шифр ***\n";
        private const string STREAM_CRYPT = "\n*** Потоковый шифр ***\n";

        private void frequencyAnalysis()
        {
            outText.AppendText(FREQUENCY_ANALISIS);
            int[] frequency = new int[alphabetLength];
            // обнуление
            for (int i = 0; i < alphabetLength; i++)
            {
                frequency[i] = 0;
            }
            // подсчет букв
            int index;
            for (int i = 0; i < text.Length; i++)
            {
                index = text[i] - alphabet[0];
                frequency[index] += 1;
            }
            // сортировка по убыванию
            List<(char, int)> frequencyCharFloat = new List<(char, int)>(alphabetLength);
            for (int i = 0; i < alphabetLength; i++)
            {
                frequencyCharFloat.Add((alphabet[i], frequency[i]));
            }
            frequencyCharFloat.Sort((a, b) => { return b.Item2 - a.Item2; });
            // вывод частот
            for (int i = 0; i < alphabetLength; i++)
            {
                outText.AppendText("Символ " + frequencyCharFloat[i].Item1 + " встречается раз: " + frequencyCharFloat[i].Item2.ToString() + "\n");
            }
            // преобразование текста
            if (alphabetFrequency != null)
            {
                string textOut = text;
                for (int i = 0; i < alphabetLength; i++)
                {

                    textOut = textOut.Replace(frequencyCharFloat[i].Item1, alphabetFrequency[i].ToString().ToUpper().ToCharArray()[0]);
                }
                // вывод текста
                outText.AppendText(textOut + "\n");
            }
        }

        private void linearCrypt()
        {
            outText.AppendText(LINEAR_CRYPT);
            int[] frequency = new int[alphabetLength];
            // обнуление
            for (int i = 0; i < alphabetLength; i++)
            {
                frequency[i] = 0;
            }
            // подсчет букв
            int index;
            for (int i = 0; i < text.Length; i++)
            {
                index = text[i] - alphabet[0];
                frequency[index] += 1;

            }
            // сортировка по убыванию
            List<(char, int)> frequencyCharFloat = new List<(char, int)>(alphabetLength);
            for (int i = 0; i < alphabetLength; i++)
            {
                frequencyCharFloat.Add((alphabet[i], frequency[i]));
            }
            frequencyCharFloat.Sort((a, b) => { return b.Item2 - a.Item2; });

            // расшифровка на основе частотного анализа
            bool first, second, third, fouth, fifth;
            string error;
            for (int a = 0; a < alphabetLength; a++)
            {
                for (int b = 0; b < alphabetLength; b++)
                {
                    first = ((alphabetFrequency[0] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[0].Item1 - alphabet[0]);
                    second = ((alphabetFrequency[1] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[1].Item1 - alphabet[0]);
                    third = ((alphabetFrequency[2] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[2].Item1 - alphabet[0]);
                    fouth = ((alphabetFrequency[3] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[3].Item1 - alphabet[0]);
                    fifth = ((alphabetFrequency[4] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[4].Item1 - alphabet[0]);
                    if (first && second || first && third || first && fouth || first && fifth || second && third || second && fouth || second && fifth || third && fouth || third && fifth || fouth && fifth)
                    {
                        error = linearDecryptProcess(text, a, b);
                        if (error != ERROR)
                        {
                            outText.AppendText("\nКлюч A - " + a + " ключ B - " + b + "\n");
                            outText.AppendText(error + "\n");
                        }
                    }
                }
            }
            // примерная расшифровка на основе частотного анализа
            for (int a = 0; a < alphabetLength; a++)
            {
                for (int b = 0; b < alphabetLength; b++)
                {
                    first = ((alphabetFrequency[0] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[0].Item1 - alphabet[0]);
                    second = ((alphabetFrequency[1] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[2].Item1 - alphabet[0]);
                    third = ((alphabetFrequency[2] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[1].Item1 - alphabet[0]);
                    fouth = ((alphabetFrequency[3] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[4].Item1 - alphabet[0]);
                    fifth = ((alphabetFrequency[4] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[3].Item1 - alphabet[0]);
                    if (first && second || first && third || first && fouth || first && fifth || second && third || second && fouth || second && fifth || third && fouth || third && fifth || fouth && fifth)
                    {
                        error = linearDecryptProcess(text, a, b);
                        if (error != ERROR)
                        {
                            outText.AppendText("\nКлюч A - " + a + " ключ B - " + b + "\n");
                            outText.AppendText(error + "\n");
                        }
                    }
                }
            }
            // и ещё
            for (int a = 0; a < alphabetLength; a++)
            {
                for (int b = 0; b < alphabetLength; b++)
                {
                    first = ((alphabetFrequency[0] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[0].Item1 - alphabet[0]);
                    second = ((alphabetFrequency[1] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[3].Item1 - alphabet[0]);
                    third = ((alphabetFrequency[2] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[4].Item1 - alphabet[0]);
                    fouth = ((alphabetFrequency[3] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[1].Item1 - alphabet[0]);
                    fifth = ((alphabetFrequency[4] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[2].Item1 - alphabet[0]);
                    if (first && second || first && third || first && fouth || first && fifth || second && third || second && fouth || second && fifth || third && fouth || third && fifth || fouth && fifth)
                    {
                        error = linearDecryptProcess(text, a, b);
                        if (error != ERROR)
                        {
                            outText.AppendText("\nКлюч A - " + a + " ключ B - " + b + "\n");
                            outText.AppendText(error + "\n");
                        }
                    }
                }
            }
            // и ещё
            for (int a = 0; a < alphabetLength; a++)
            {
                for (int b = 0; b < alphabetLength; b++)
                {
                    first = ((alphabetFrequency[0] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[0].Item1 - alphabet[0]);
                    second = ((alphabetFrequency[1] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[4].Item1 - alphabet[0]);
                    third = ((alphabetFrequency[2] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[2].Item1 - alphabet[0]);
                    fouth = ((alphabetFrequency[3] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[3].Item1 - alphabet[0]);
                    fifth = ((alphabetFrequency[4] - alphabet[0]) * a + b) % alphabetLength == (frequencyCharFloat[1].Item1 - alphabet[0]);
                    if (first && second || first && third || first && fouth || first && fifth || second && third || second && fouth || second && fifth || third && fouth || third && fifth || fouth && fifth)
                    {
                        error = linearDecryptProcess(text, a, b);
                        if (error != ERROR)
                        {
                            outText.AppendText("\nКлюч A - " + a + " ключ B - " + b + "\n");
                            outText.AppendText(error + "\n");
                        }
                    }
                }
            }
        }

        private string linearDecryptProcess(string text, int a, int b)
        {
            if (a % 2 == 0 || a % 13 == 0)
            {
                return ERROR;
            }

            int a_ = 0;
            while ((a * a_) % alphabetLength != 1)
            {
                a_++;
            }

            int result, y;
            string result_text = "";
            for (int i = 0; i < text.Length; i++)
            {
                y = (text[i] - alphabet[0]);
                result = a_ * (y - b);
                while (result < 0)
                {
                    result += alphabetLength;
                }
                result = result % alphabetLength;
                result_text += alphabet[result];
            }
            return result_text;
        }

        private const string STREAM_X_Y_LENGTH_ERROR = "\n*** Исходный текст длиннее или короче чем шифротекст ***\n";

        private void streamCrypt()
        {
            outText.AppendText(STREAM_CRYPT);
            string[] streamKXY;
            streamKXY = text.Split('\n');
            if ((streamKXY[1].Length - 1) != streamKXY[2].Length)
            {
                outText.AppendText(STREAM_X_Y_LENGTH_ERROR);
                return;
            }
            // разрядность регистра
            int k = Convert.ToInt32(streamKXY[0]);
            // ключевой поток
            int[] streamZ = new int[streamKXY[2].Length];
            for (int i = 0; i < streamZ.Length; i++)
            {
                streamZ[i] = Convert.ToByte((streamKXY[2][i] + streamKXY[1][i]) % alphabetLength);
            }
            // вывод ключевого потока
            string streamZ_ = "";
            foreach (var item in streamZ)
            {
                streamZ_ += item.ToString();
            }
            outText.AppendText("Ключевой поток\n" + streamZ_ + "\n");
            for (int offset = 0; offset < streamZ.Length - 2 * k; offset++)
            {
                outText.AppendText("Попытка вычислить при смещении " + offset.ToString() + "\n");
                // составление матрицы
                int[,] bigMatrix = new int[k, k];
                for (int a = 0; a < k; a++)
                {
                    for (int b = 0; b < k; b++)
                    {
                        bigMatrix[a, b] = streamZ[a + b + offset];
                    }
                }
                outText.AppendText("Из ключевого потока создана матрица\n");
                outText.AppendText(matrixToString(ref bigMatrix));
                // поиск союзной матрицы
                int[,] bigMatrix_ = new int[k, k];
                for (int a = 0; a < k; a++)
                {
                    for (int b = 0; b < k; b++)
                    {
                        bigMatrix_[a, b] = calcAlgAdd(ref bigMatrix, b, a);
                    }
                }
                outText.AppendText("Найдена союзная матрица\n");
                outText.AppendText(matrixToString(ref bigMatrix_));
                // поиск определителя
                int det = calcDet(ref bigMatrix);
                // плохо
                if (det == 0)
                {
                    outText.AppendText("Определитель равен нулю\n");
                }
                // вычисление коэффициентов
                else
                {
                    int[] result = new int[k];
                    for (int i = 0; i < k; i++)
                    {
                        result[i] = 0;
                        for (int a = 0; a < k; a++)
                        {
                            result[i] += streamZ[a + k + 1] * bigMatrix_[a, i];
                        }
                    }
                    // нормализация
                    for (int i = 0; i < k; i++)
                    {
                        result[i] = getModInt(result[i]);
                    }
                    // вывод
                    outText.AppendText("Коэффициенты\n");
                    for (int i = 0; i < k; i++)
                    {
                        outText.AppendText(result[i].ToString() + " ");
                    }
                    outText.AppendText("\n");
                    return;
                }
            }
            
        }

        private string matrixToString(ref int[,] matrix)
        {
            string result = "";
            for (int a = 0; a < matrix.GetLength(0); a++)
            {
                for (int b = 0; b < matrix.GetLength(1); b++)
                {
                    result += matrix[a, b].ToString() + " ";
                }
                result += "\n";
            }
            return result;
        }

        private int calcAlgAdd(ref int[,] matrix, int a, int b)
        {
            if ((a + b) % 2 == 0)
            {
                return getModInt(getMinor(ref matrix, a, b));
            }
            else
            {
                return getModInt(-getMinor(ref matrix, a, b));
            }
        }

        private int getMinor(ref int[,] matrix, int a, int b)
        {
            int length = matrix.GetLength(0) - 1;
            int[,] buff;
            buff = new int[length, length];
            length++;
            // счетчики
            int c_a = 0, c_b = 0;
            for (int a_ = 0; a_ < length; a_++)
            {
                if (a_ == a)
                {
                    continue;
                }

                for (int b_ = 0; b_ < length; b_++)
                {
                    if (b_ == b)
                    {
                        continue;
                    }

                    buff[c_a, c_b++] = matrix[a_, b_];
                }

                if (c_b == length - 1)
                {
                    c_a++;
                    c_b = 0;
                }
            }
            return calcDet(ref buff);
        }

        private int getModInt(int a)
        {
            while (a < 0)
            {
                a += alphabetLength;
            }
            while (a >= alphabetLength)
            {
                a -= alphabetLength;
            }
            return a;
        }

        private int calcDet(ref int[,] matrix)
        {
            int sum = 0;
            int length = matrix.GetLength(0);
            if (length == 1)
            {
                return getModInt(matrix[0, 0]);
            }
            else if (length == 2)
            {
                return getModInt(matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]);
            }
            // понижение порядка
            else
            {
                for (int i = 0; i < length; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (matrix[0,i] != 0) sum += getMinor(ref matrix, 0, i);
                    }
                    else
                    {
                        if (matrix[0, i] != 0) sum -= getMinor(ref matrix, 0, i);
                    }
                    
                }
                return getModInt(sum);
            }
        }

        private void decrypt_Click(object sender, EventArgs e)
        {
            decryptorProcess();
        }

        private void clearOutText_Click(object sender, EventArgs e)
        {
            outText.Clear();
        }
    }


}
