# Exercitiul 3 — Strategy, pe cont propriu: export de raport

> Practica pe Strategy (ex1), domeniu nou. De data asta nu-ti mai dau pasii — ai vazut mecanismul, acum il aplici singur. Teoria e in `TEORIE.pdf`, lectia 1.

## Problema

Un raport are niste randuri de text (`string[]`) si trebuie exportat in mai multe **formate**: CSV, text numerotat, Markdown. Formatul se poate schimba la runtime, iar un format nou nu trebuie sa te oblige sa modifici raportul.

Recunosti forma: o familie de algoritmi interschimbabili in spatele unui contract. E Strategy.

## Contractul (dat)

```csharp
public interface IExportStrategie
{
    string Nume { get; }
    string Formateaza(string[] randuri);
}
```

## Ce construiesti tu

| Ce | Detalii |
|---|---|
| `ExportCsv` | `Nume = "CSV"`; toate randurile pe O linie, separate prin virgula: `a,b,c` |
| `ExportText` | `Nume = "Text"`; fiecare rand pe linia lui, numerotat: `1. a` apoi `2. b` ... |
| `ExportMarkdown` | `Nume = "Markdown"`; fiecare rand ca bullet: `- a` apoi `- b` ... |
| `Raport` (Context) | tine `string[]` cu datele si o `IExportStrategie`; `Genereaza()` intoarce textul formatat; `SchimbaFormat(IExportStrategie)` schimba formatul |

## Cerinte

1. Contractul + cele 3 strategii + `Raport`.
2. `Testare3` (chemata din `Program.cs`): un raport cu 3-4 randuri; il generezi cu CSV, apoi `SchimbaFormat` pe Text, apoi pe Markdown; dupa fiecare afisezi `Nume`-le formatului si rezultatul.
3. In output trebuie sa se vada ACELEASI date in 3 forme diferite.

## Constrangeri

- `Raport` NU are `if`/`switch` pe format — decizia traieste in strategii.
- Fara `is`, `as`, `GetType()`. Fara LINQ (`string.Join` e permis pentru CSV; restul cu `for`). Fara `List`.
- Pentru numerotare/bullets construieste textul cu `for`.

## Intrebare de gandit

- La ex1, strategia primea date prin parametri si era fara stare. Aici la fel: `Formateaza` primeste randurile ca parametru. Ce s-ar strica daca `ExportCsv` ar tine randurile intr-un camp al lui, si ai refolosi aceeasi instanta pentru doua rapoarte?
