# Exercitiul 1 — Strategy: schimbi comportamentul, nu clasa

## Context

Un magazin online calculeaza **costul de livrare** al unei comenzi. Costul depinde de metoda aleasa: standard, express sau o promotie „livrare gratuita". Aceeasi comanda (aceeasi greutate, aceeasi distanta) da alt cost, in functie de metoda.

Prima varianta la care se gandeste oricine: o metoda cu un `switch` pe un enum `TipLivrare`. Merge. Problema apare cand firma adauga a patra metoda de livrare — si a cincea. Fix problema pe care ai batut-o la **interfaces ex5 (open/closed)**: ca sa adaugi un comportament nou, esti obligat sa RE-DESCHIZI si sa editezi o metoda care deja mergea.

**Strategy** e raspunsul: fiecare metoda de calcul devine o clasa separata care semneaza acelasi contract. `Comanda` nu mai stie CUM se calculeaza — tine o strategie si o intreaba. Poti schimba strategia la runtime, iar o metoda noua = o clasa noua, fara sa atingi nimic din ce merge deja.

## Contractul

```csharp
public interface ILivrareStrategie
{
    string Nume { get; }
    decimal CalculeazaCost(decimal greutateKg, decimal distantaKm);
}
```

`Comanda` lucreaza doar cu `ILivrareStrategie` — nu-i pasa ce strategie concreta i-ai dat, doar ca stie sa calculeze un cost.

## Strategiile (formulele)

| Strategie | `Nume` | Cost |
|---|---|---|
| `LivrareStandard` | `"Standard"` | `5 + 0.5 * greutate + 0.1 * distanta` |
| `LivrareExpress` | `"Express"` | `12 + 1.0 * greutate + 0.25 * distanta` |
| `LivrareGratuita` | `"Gratuita"` | `0` (promotie — ignora greutatea si distanta) |

## Pasii (in ordinea asta — primul pas e o capcana intentionata)

1. **Simte durerea intai.** Pe o foaie (sau intr-o metoda pe care o STERGI dupa), scrie calculul cu `switch (tip)` pe un enum `TipLivrare { Standard, Express, Gratuita }`. Functioneaza. Acum raspunde: daca maine apare `LivrareInternationala`, cate locuri din cod atingi? Ce reguli din open/closed incalci?
2. **Extrage fiecare ramura intr-o clasa-strategie.** Cele 3 clase din tabel implementeaza `ILivrareStrategie`. Fiecare tine DOAR formula ei — nimeni nu mai stie de celelalte.
3. **Injecteaza si schimba la runtime.** `Comanda` primeste o strategie prin constructor si are `SchimbaStrategie(ILivrareStrategie noua)`. `CostTransport()` deleaga strategiei curente — fara niciun `if`/`switch` pe tip in `Comanda`.

## Cerinte

1. Interfata `ILivrareStrategie` + cele 3 strategii.
2. `Comanda` cu: `Client`, `GreutateKg`, `DistantaKm`, o strategie injectata, `SchimbaStrategie(...)` si `CostTransport()`. Constructorul valideaza: greutate `<= 0` sau distanta `< 0` arunca `ArgumentException` (mesaj in engleza).
3. `Testare1` (chemata din `Program.cs`, ca la interfaces): o singura `Comanda`; calculeaza costul cu `LivrareStandard`, apoi `SchimbaStrategie` pe `LivrareExpress`, apoi pe `LivrareGratuita`; dupa fiecare afiseaza numele strategiei si costul. In output trebuie sa se vada ACEEASI comanda cu 3 costuri diferite.
4. Demonstreaza validarea: incearca sa construiesti o comanda cu greutate `0`, prinde `ArgumentException` si afiseaza mesajul.

## Constrangeri

- `Comanda` NU are voie sa contina `switch`/`if` pe tipul de livrare — toata logica de tip traieste in strategii.
- Fara `is`, `as`, `GetType()`. Fara LINQ, `List`, `Dictionary` — nu-ti trebuie aici.
- Mesajele de eroare in engleza.

## Cum rulezi

```bash
dotnet run
```

## Bonus (privire inainte spre Decorator, lectia 4)

- Scrie o strategie `LivrareCuReducere` care primeste in constructor O ALTA `ILivrareStrategie` si un procent, si returneaza costul strategiei interioare minus procentul. Observa: o strategie care impacheteaza alta strategie... exact asta e un **Decorator**. Il vom numi asa peste 3 lectii — deocamdata bucura-te ca Strategy ti l-a aratat gratis.
- Intrebare de gandit: de ce `CalculeazaCost` primeste `greutate` si `distanta` ca PARAMETRI, si nu ii tine strategia ca stare in campuri? Ce s-ar strica daca ai refolosi aceeasi instanta `LivrareStandard` pentru doua comenzi diferite, cu greutati diferite?
