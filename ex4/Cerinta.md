# Exercitiul 4 — Observer, pe cont propriu: statie meteo

> Practica pe Observer (ex2), domeniu nou. Fara pasi de data asta. Teoria e in `TEORIE.pdf`, lectia 2.

## Problema

O statie meteo masoara temperatura. La fiecare masuratoare noua, mai multe **afisaje** trebuie sa reactioneze — dar fac lucruri diferite, nu doar sa printeze acelasi lucru:

- unul arata temperatura curenta;
- unul tine **statistica** rulanta (minim, maxim, media de pana acum);
- unul da **alerta** cand se depaseste un prag.

O sursa, N reactii independente. E Observer — dar aici observatorii au **stare proprie**, nu doar afiseaza.

## Contractul (dat)

```csharp
public interface IAfisaj
{
    void Actualizeaza(decimal temperatura);
}
```

## Ce construiesti tu

| Ce | Detalii |
|---|---|
| `AfisajCurent` | afiseaza `[CURENT] Acum: X` |
| `AfisajStatistica` | tine minimul, maximul si media temperaturilor primite pana acum; afiseaza `[STATISTICA] Min: a | Max: b | Media: c` |
| `AfisajAlerta` | daca `temperatura > 30` afiseaza `[ALERTA] Temperatura ridicata: X`; altfel afiseaza `[ALERTA] OK` |
| `StatieMeteo` (Subject) | tine `IAfisaj[]` prin constructor; `SeteazaTemperatura(decimal t)` retine temperatura si anunta toate afisajele |

## Cerinte

1. Contractul + cele 3 afisaje + `StatieMeteo`.
2. `Testare4` (chemata din `Program.cs`): creezi cele 3 afisaje, o statie cu ele, apoi `SeteazaTemperatura` de 3-4 ori cu valori diferite (ex: 25, 32, 28). In output trebuie sa vezi, la fiecare masuratoare, toate cele 3 reactii — si statistica sa se acumuleze (media se schimba de la o masuratoare la alta).

## Constrangeri

- `StatieMeteo` NU cunoaste nicio clasa concreta de afisaj — doar `IAfisaj`.
- Fara `is`, `as`, `GetType()`. Fara LINQ, `List`, `Dictionary` — pentru statistica tine tu campurile (min, max, suma, numar) si calculeaza media.
- Mesajele de eroare in engleza.

## Intrebare de gandit

- `AfisajStatistica` are stare care creste in timp; `AfisajCurent` nu tine nimic. Amandoua semneaza acelasi contract `IAfisaj`. Ce castigi din faptul ca `StatieMeteo` nu stie care observator tine stare si care nu? Daca maine adaugi un `AfisajGrafic` care deseneaza un istoric, cate linii din `StatieMeteo` atingi?
