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
            var text = File.ReadAllText(FilePath, Encoding.UTF8);
            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            var currentEntry = new StringBuilder();

            foreach (var line in lines)
            {
                if (line.StartsWith("## "))
                {
                    if (currentEntry.Length > 0)
                    {
                        var trimmed = currentEntry.ToString().Trim();
                        if (!string.IsNullOrEmpty(trimmed))
                        {
                            _notes.Add(trimmed);
                        }
                        currentEntry.Clear();
                    }
                }
                currentEntry.AppendLine(line);
            }

            if (currentEntry.Length > 0)
            {
                var trimmed = currentEntry.ToString().Trim();
                if (!string.IsNullOrEmpty(trimmed))
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
            StatusText.Text = "Wpisz tytuł lub treść notatki.";
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

        try
        {
            File.WriteAllText(FilePath, fullContent, Encoding.UTF8);
            StatusText.Text = "Zapisano";
            TitleBox.Text = string.Empty;
            ContentBox.Text = string.Empty;
            LoadNotes();
        }
        catch (Exception ex)
        {
            StatusText.Text = $"Nie udało się zapisać: {ex.Message}";
        }
    }
}