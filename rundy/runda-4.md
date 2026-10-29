# Wynik rundy 4: trzy przykłady zamiast jednego (few-shot)

Prośba wysłana do agenta:
> "Notatki zapisuj do pliku notatki.md w folderze projektu. Najnowsza notatka zawsze na samej górze pliku. Między notatkami jedna pusta linia. Polskie znaki mają być zachowane w kodowaniu UTF-8.
> 
> Plik ma wyglądać dokładnie według poniższych trzech przykładów:
> 
> ## 2026-09-08 14:32 — Zakupy
> mleko
> 
> ## 2026-09-07 09:15 — Pomysł na projekt
> minutnik z historią sesji
> dodać testy jednostkowe
> sprawdzić działanie w systemie Windows
> 
> ## 2026-09-06 18:45 — Ważne spotkanie — podsumowanie i wnioski
> Zażółć gęślą jaźń — omówiono nowe założenia projektu oraz błędy zapisu."

Plik powstały na dysku po uruchomieniu aplikacji i zapisaniu notatek: `notatki.md`

Zawartość pliku `notatki.md`:
```markdown
## 2026-10-29 08:31 — Ważne spotkanie — podsumowanie i wnioski
Zażółć gęślą jaźń — omówiono nowe założenia projektu oraz błędy zapisu.

## 2026-10-29 08:30 — Pomysł na projekt
minutnik z historią sesji
dodać testy jednostkowe
sprawdzić działanie w systemie Windows

## 2026-10-29 08:29 — Zakupy
mleko
```

### Spostrzeżenia:
- Trzy zróżnicowane przykłady (*few-shot*) eliminują wszelką niejednoznaczność: model zobaczył przypadek jedno-wierszowy, wielowierszowy oraz tytuł zawierający dodatkowy myślnik i polskie znaki diakrytyczne.
- Format jest w 100% stabilny i powtarzalny. Nie wymaga skomplikowanego opisu gramatycznego ani wielostronicowych regulaminów.
- Po rundzie 4 format pliku jest docelowy i w pełni spełnia wymagania specyfikacji.
