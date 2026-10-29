# Wynik rundy 3: przykład działa lepiej niż opis (one-shot)

Prośba wysłana do agenta:
> "Plik ma wyglądać dokładnie tak:
> 
> ## 2026-09-08 14:32 — Zakupy
> mleko
> chleb
> 
> ## 2026-09-07 09:15 — Pomysł na projekt
> minutnik z historią sesji"

Plik powstały na dysku po uruchomieniu aplikacji i zapisaniu notatek: `notatki.md`

Zawartość pliku `notatki.md`:
```markdown
## 2026-10-29 08:31 — Pomysł na projekt
minutnik z historią sesji

## 2026-10-29 08:30 — Zakupy
mleko
chleb
```

### Spostrzeżenia:
- Zastosowanie techniki *one-shot* (jeden konkretny przykład w prompcie) ujednoznaczniło format bez konieczności tworzenia drobiazgowych opisów reguł formatowania.
- Model precyzyjnie odwzorował format nagłówka (`## YYYY-MM-DD HH:mm — Tytuł`), sposób podziału linii w treści oraz pojedynczą pustą linię jako separator wpisów.
- Ograniczenie techniki *one-shot*: Pojedynczy przykład nie pokazuje wszystkich wariantów brzegowych (np. wpis jednolinijkowy vs wielolinijkowy, tytuły zawierające dodatkowe myślniki lub znaki specjalne).
