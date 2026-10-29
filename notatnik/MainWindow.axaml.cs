using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace notatnik;

public partial class MainWindow : Window
{
    private const string FilePath = "notatki.md";
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
            var content = File.ReadAllText(FilePath, Encoding.UTF8);
            var sections = content.Split(new[] { "\n\n## ", "\r\n\r\n## " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var section in sections)
            {
                var entry = section.Trim();
                if (!entry.StartsWith("## "))
                {
                    entry = "## " + entry;
                }
                _notes.Add(entry);
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

        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        var newEntry = $"## {timestamp} — {title}\n{content}";

        string fullContent;
        if (File.Exists(FilePath))
        {
            var existingContent = File.ReadAllText(FilePath, Encoding.UTF8).Trim();
            if (string.IsNullOrWhiteSpace(existingContent))
            {
                fullContent = newEntry + "\n";
            }
            else
            {
                fullContent = newEntry + "\n\n" + existingContent + "\n";
            }
        }
        else
        {
            fullContent = newEntry + "\n";
        }

        File.WriteAllText(FilePath, fullContent, Encoding.UTF8);

        TitleBox.Text = string.Empty;
        ContentBox.Text = string.Empty;

        LoadNotes();
    }
}