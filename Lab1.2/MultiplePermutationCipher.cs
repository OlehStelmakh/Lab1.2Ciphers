using System;
using System.Collections.Generic;

namespace Lab1._2
{
    public class MultiplePermutationCipher
    {
        public string Encrypt(Table table, Tuple<List<int>, List<int>> key)
        {
            //permutation of columns
            char[,] forColumnsPermutationText = new char[table.AmountOfRows, table.AmountOfColumns];

            for (int i = 0; i < key.Item2.Count; i++)
            {
                int column = key.Item2[i];
                for (int j = 0; j < table.AmountOfRows; j++)
                {
                    forColumnsPermutationText[j, column] = table.CreatedTable[j, i];
                }
            }

            table.CreatedTable = forColumnsPermutationText;
            table.PrintTable();

            // permutation of rows
            char[,] forRowsPermutationText = new char[table.AmountOfRows, table.AmountOfColumns];

            for (int i = 0; i < key.Item1.Count; i++)
            {
                int row = key.Item1[i];
                for (int j = 0; j < table.AmountOfColumns; j++)
                {
                    forRowsPermutationText[row, j] = forColumnsPermutationText[i, j];
                }
            }

            table.CreatedTable = forRowsPermutationText;
            table.PrintTable();

            return table.CreateStringFromCreatedTable();
        }

        public string Decrypt(Table table, Tuple<List<int>, List<int>> key)
        {
            // permutation of rows
            char[,] forRowsBeforePermutationText = new char[table.AmountOfRows, table.AmountOfColumns];

            for (int i = 0; i < key.Item1.Count; i++)
            {
                int row = key.Item1[i];
                for (int j = 0; j < table.AmountOfColumns; j++)
                {
                    forRowsBeforePermutationText[i, j] = table.CreatedTable[row, j];
                }
            }

            table.CreatedTable = forRowsBeforePermutationText;
            table.PrintTable();

            // permutation of columns
            char[,] forColumnsBeforePermutationText = new char[table.AmountOfRows, table.AmountOfColumns];

            for (int i = 0; i < key.Item2.Count; i++)
            {
                int column = key.Item2[i];
                for (int j = 0; j <table.AmountOfRows; j++)
                {
                    forColumnsBeforePermutationText[j, i] = forRowsBeforePermutationText[j, column];
                }
            }

            table.CreatedTable = forColumnsBeforePermutationText;
            table.PrintTable();

            return table.CreateStringFromCreatedTable();
        }

        public Tuple<List<int>, List<int>> CreatePermutationNumbers(Table table)
        {
            List<int> rowNumbers = new List<int>();
            List<int> columnNumbers = new List<int>();

            for (int i = 0; i < table.AmountOfRows; i++)
            {
                rowNumbers.Add(i);
            }

            for (int j = 0; j < table.AmountOfColumns; j++)
            {
                columnNumbers.Add(j);
            }

            rowNumbers.Shuffle();
            columnNumbers.Shuffle();

            return new Tuple<List<int>, List<int>>(rowNumbers, columnNumbers);
        }
    }

    public class Table
    {
        public int AmountOfColumns { get; private set; }
        public int AmountOfRows { get; private set; }
        public int Remainder { get; private set; } = 0;
        public char[,] CreatedTable { get; set; }

        public Table(string text, int amountOfColumns)
        {
            AmountOfColumns = amountOfColumns;
            CreatedTable = CreateTable(text);
        }

        private char[,] CreateTable(string text)
        {
            if (text.Length % AmountOfColumns != 0)
            {
                Remainder = AmountOfColumns - (text.Length % AmountOfColumns);
            }
            string localText = text + new string(' ', Remainder);

            AmountOfRows = localText.Length / AmountOfColumns;

            char[,] table = new char[AmountOfRows, AmountOfColumns];

            for (int i = 0; i < AmountOfRows; i++)
            {
                for (int j = 0; j < AmountOfColumns; j++)
                {
                    table[i, j] = localText[i * AmountOfColumns + j];
                }
            }

            return table;
        }

        public void PrintTable()
        {
            for (int i = 0; i < AmountOfRows; i++)
            {
                for (int j = 0; j < AmountOfColumns; j++)
                {
                    Console.Write(CreatedTable[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public string CreateStringFromCreatedTable()
        {
            string result = string.Empty;
            for (int i = 0; i < AmountOfRows; i++)
            {
                for (int j = 0; j < AmountOfColumns; j++)
                {
                    result += CreatedTable[i, j];
                }
            }

            return result;
        }
    }
}
