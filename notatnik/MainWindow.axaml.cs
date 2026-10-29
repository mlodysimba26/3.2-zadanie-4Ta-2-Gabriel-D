using System.Collections.Generic;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace notatnik;

public partial class MainWindow : Window
{
    private const string FilePath = "notes.txt";
    private readonly List<string> _notes = new();

    public MainWindow()
    {
        InitializeComponent();
        LoadNotes();
    }

    private void LoadNotes()
    {
        _notes.Clear();
        if (File.Exists(FilePath))
        {
            var content = File.ReadAllText(FilePath);
            var items = content.Split(new[] { "---" }, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                var trimmed = item.Trim();
                if (!string.IsNullOrWhiteSpace(trimmed))
                {
                    _notes.Add(trimmed);
                }
            }
        }
        NotesListBox.ItemsSource = _notes.ToArray();
    }

    private void SaveButton_Click(object? sender, RoutedEventArgs e)
    {
        var title = TitleBox.Text?.Trim() ?? string.Empty;
        var content = ContentBox.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(content))
        {
            return;
        }

        var entry = $"Tytuł: {title}\nTreść: {content}\n---\n";
        File.AppendAllText(FilePath, entry);

        TitleBox.Text = string.Empty;
        ContentBox.Text = string.Empty;

        LoadNotes();
    }
}